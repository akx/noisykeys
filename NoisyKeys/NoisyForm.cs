using System;
using System.Linq;
using System.Windows.Forms;
using CoreAudioApi;

namespace NoisyKeys {
	public partial class NoisyForm : Form {
		private MMDevice[] _micDevices;
		private DateTime _lastKeypressTime;
		private DateTime _firstKeypressTime;
		private int _phase;
		private readonly Timer _resetTimer = new Timer();

		public NoisyForm() {
			InitializeComponent();
			Shown += delegate { 
				var devEnum = new MMDeviceEnumerator();
				var devices = devEnum.EnumerateAudioEndPoints(EDataFlow.eCapture, EDeviceState.DEVICE_STATE_ACTIVE);
				_micDevices = devices.Where(d => d.FriendlyName.ToLower().Contains("micro")).ToArray();
				var interceptor = new InterceptKeys(KeyProc);
				Closing += delegate { interceptor.Dispose(); };
				_resetTimer.Tick += ResetTick;
				SetStatus(string.Format("Working on {0} mics", _micDevices.Length));
			};
		}

		private void ResetTick(object sender, EventArgs eventArgs) {
			var attackMs = (int) attackTimeBox.Value;
			var releaseMs = (int) releaseTimeBox.Value;

			if (_phase == 1) {
				if ((DateTime.Now - _lastKeypressTime).TotalMilliseconds > attackMs) {
					_phase = 0;
					_resetTimer.Stop();
				}
				else if ((DateTime.Now - _firstKeypressTime).TotalMilliseconds > attackMs) {
					SetMute(true);
					_phase = 2;
				}
			} else if (_phase == 2) {
				if ((DateTime.Now - _lastKeypressTime).TotalMilliseconds > releaseMs) {
					ResetMuting();
				}
			}
		}

		private void SetStatus(string status) {
			if (InvokeRequired) {
				Invoke(new Action(delegate { statusLabel.Text = status; }));
			}
			else {
				statusLabel.Text = status;
			}
		}

		private void ResetMuting() {
			SetMute(false);
			_phase = 0;
			_resetTimer.Stop();
		}

		private void SetMute(bool mute) {
			foreach (var dev in _micDevices) {
				dev.AudioEndpointVolume.Mute = mute;
			}
			SetStatus(string.Format("Set mute to {0}", mute));
		}

		private void KeyProc(Keys key) {
			if (_phase == 0) {
				_firstKeypressTime = _lastKeypressTime = DateTime.Now;
				_resetTimer.Interval = 20;
				_resetTimer.Start();
				_phase = 1;
			}
			else if (_phase == 1 || _phase == 2) {
				_lastKeypressTime = DateTime.Now;
			}
		}

		private void UnmuteClick(object sender, EventArgs e) {
			ResetMuting();
		}


	}
}
