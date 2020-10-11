﻿/*
Technitium Library
Copyright (C) 2020  Shreyas Zare (shreyas@technitium.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TechnitiumLibrary.Net.Proxy
{
    public class DefaultProxyServerConnectionManager : IProxyServerConnectionManager
    {
        public virtual async Task<Socket> ConnectAsync(EndPoint remoteEP)
        {
            if (remoteEP.AddressFamily == AddressFamily.Unspecified)
                remoteEP = await remoteEP.GetIPEndPointAsync();

            Socket socket = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await socket.ConnectAsync(remoteEP);

            socket.NoDelay = true;

            return socket;
        }

        public Task<IProxyServerUdpHandler> GetUdpHandlerAsync(EndPoint localEP)
        {
            IProxyServerUdpHandler udpHandler = new UdpSocketHandler(localEP);
            return Task.FromResult(udpHandler);
        }

        class UdpSocketHandler : IProxyServerUdpHandler
        {
            #region variables

            Socket _socket;

            #endregion

            #region constructor

            public UdpSocketHandler(EndPoint localEP)
            {
                _socket = new Socket(localEP.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                _socket.Bind(localEP);
            }

            #endregion

            #region public

            public void Dispose()
            {
                _socket.Dispose();
            }

            public Task<UdpReceiveFromResult> ReceiveFromAsync(byte[] buffer, int offset, int count)
            {
                return _socket.ReceiveFromAsync(buffer, offset, count);
            }

            public Task SendToAsync(byte[] buffer, int offset, int count, EndPoint remoteEP)
            {
                return _socket.SendToAsync(buffer, offset, count, remoteEP);
            }

            #endregion
        }
    }
}
