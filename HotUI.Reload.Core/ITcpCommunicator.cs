﻿using System;
using System.Threading.Tasks;

namespace HotUI.Internal.Reload {
	public interface ICommunicator
	{
		Action<object> DataReceived { get; set; }

		Task<bool> Send<T>(T obj);
	}

	public interface ITcpCommunicatorClient : ICommunicator {
		Task<bool> Connect (string ip, int port);

		void Disconnect ();
	}

	public interface ITcpCommunicatorServer : ICommunicator {
		event EventHandler ClientConnected;

		int ClientsCount { get; }

		Task<bool> StartListening (int serverPort);

		void StopListening ();
	}
}