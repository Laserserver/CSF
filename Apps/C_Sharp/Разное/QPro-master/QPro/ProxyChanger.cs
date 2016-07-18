using System;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace QPro {
    /// <summary>
    ///     Представляет класс для изменения на лету прокси-сервера для всей системы
    /// </summary>
    internal class ProxyChanger {
        private const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        private const int INTERNET_OPTION_REFRESH = 37;

        private static readonly IntPtr HwndBroadcast = new IntPtr(0xffff);
        private static readonly IntPtr WmSettingchange = new IntPtr(0x001A);

        private bool oldEnabled;
        private IPEndPoint oldEndPoint;

        [DllImport("wininet.dll", EntryPoint = "InternetSetOptionA",
            CharSet = CharSet.Ansi, SetLastError = true, PreserveSig = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(IntPtr hWnd,
                                                        uint Msg,
                                                        UIntPtr wParam,
                                                        UIntPtr lParam,
                                                        SendMessageTimeoutFlags fuFlags,
                                                        uint uTimeout,
                                                        out UIntPtr lpdwResult);

        private void ChangeIpAddressInRegistry(bool enabledProxy, IPEndPoint endPoint) {
            const string internetSettingsPath = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(internetSettingsPath)) {
                if (regKey == null) {
                    return;
                }
                if (enabledProxy) {
                    regKey.SetValue("ProxyEnable", 1);
                    regKey.SetValue("ProxyServer", endPoint);
                } else {
                    regKey.SetValue("ProxyEnable", 0);
                    regKey.SetValue("ProxyServer", "");
                }

                regKey.Close();
            }
        }

        private void SetOptions() {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            UIntPtr result;
            SendMessageTimeout(HwndBroadcast, (uint)WmSettingchange, UIntPtr.Zero, UIntPtr.Zero,
                               SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out result);
        }

        /// <summary>
        ///     Сохраняет текущие настройки прокси-сервера
        /// </summary>
        private void SaveProxySettings() {
            const string internetSettingsPath = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(internetSettingsPath)) {
                if (regKey == null) {
                    return;
                }
                var proxyEnableString = (Int32)regKey.GetValue("ProxyEnable");
                var proxyServerString = (string)regKey.GetValue("ProxyServer");

                oldEnabled = proxyEnableString == 1;

                if (oldEnabled) {
                    var d = proxyServerString.Split(':');
                    IPAddress ipAddress = null;
                    ipAddress = d[0] == "localhost"
                                    ? IPAddress.Loopback
                                    : IPAddress.Parse(d[0]);
                    var port = int.Parse(d[1]);
                    oldEndPoint = new IPEndPoint(ipAddress, port);
                } else {
                    oldEndPoint = null;
                }

                regKey.Close();
            }
        }

        /// <summary>
        ///     Устанавливает новый прокси-сервер
        /// </summary>
        /// <param name="endPoint">адрес конечной точки для прокси-сервера</param>
        public void SetNewProxy(IPEndPoint endPoint) {
            SaveProxySettings();
            ChangeIpAddressInRegistry(true, endPoint);
            SetOptions();
        }

        /// <summary>
        ///     Восстанавливает исходные настройки для прокси-сервера
        /// </summary>
        public void ResetProxy() {
            ChangeIpAddressInRegistry(oldEnabled, oldEndPoint);
            SetOptions();
        }

        private enum SendMessageTimeoutFlags : uint {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
    }
}