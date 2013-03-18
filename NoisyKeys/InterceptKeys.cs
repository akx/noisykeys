using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NoisyKeys {
	internal delegate void KeyEvent(Keys key);

	class InterceptKeys: IDisposable {
		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);


		private const int WhKeyboardLl = 13;
		private const int WmKeydown = 0x0100;
		private readonly KeyEvent _proc;
		private IntPtr _hookId = IntPtr.Zero;

		public InterceptKeys(KeyEvent proc) {
			_proc = proc;
			using (Process curProcess = Process.GetCurrentProcess()) {
				using (ProcessModule curModule = curProcess.MainModule) {
					_hookId = SetWindowsHookEx(WhKeyboardLl, HookCallback, GetModuleHandle(curModule.ModuleName), 0);
				}
			}
		}

		private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
			if (nCode >= 0 && wParam == (IntPtr)WmKeydown) {
				int vkCode = Marshal.ReadInt32(lParam);
				_proc((Keys) vkCode);
			}
			return CallNextHookEx(_hookId, nCode, wParam, lParam);
		}

		
		public void Dispose() {
			UnhookWindowsHookEx(_hookId);
			_hookId = IntPtr.Zero;
		}
	}
}
