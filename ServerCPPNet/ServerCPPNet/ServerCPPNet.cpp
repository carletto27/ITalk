#include <iostream>
#include <WS2tcpip.h>
#include <string>
#include <sstream>
#include <windows.h>
#include <winsock2.h>
#include <stdlib.h>
#include <stdio.h>
#include "server.h"
#include <map>

#undef UNICODE
#define WIN32_LEAN_AND_MEAN
#pragma comment (lib, "ws2_32.lib")

using namespace std;



void main()
{
	server s1;
	SOCKET ListenSocket = s1.start();
	map <int , SOCKET> associazione;
	pair <int, SOCKET> elem = {0,0};
	associazione.insert(elem);
	int idcl = 0;
	
	fd_set master;
	FD_ZERO(&master);
 

	FD_SET(ListenSocket, &master);

	bool running = true; 

	while (running)
	{
		fd_set copy = master;
		int socketCount = select(0, &copy, nullptr, nullptr, nullptr);

		for (int i = 0; i < socketCount; i++)
		{
			SOCKET sock = copy.fd_array[i];
			map <int, SOCKET>::iterator it;
			bool ver = false;

			for (it = associazione.begin(); it != associazione.end(); it++)
			{
				if (it->second == sock) {
					ver = true;
				}
			}
			if (ver == false) {
				int idcl1 = rand();
				idcl = idcl1;
				pair <int, SOCKET> elem = { idcl1,sock };
				associazione.insert(elem);
			}


			if (sock == ListenSocket)
			{						
				master = s1.acceptation(ListenSocket, master);			
			}
			else
			{
				char buf[4096];
				ZeroMemory(buf, 4096);

				int bytesIn = recv(sock, buf, 4096, 0);
				if (bytesIn <= 0)
				{
					closesocket(sock);
					FD_CLR(sock, &master);
				}
				else
				{
					s1.scelta(buf, sock, idcl, associazione);															
				}
			}
		}
	}

	master = s1.close(ListenSocket,master);

	WSACleanup();

	system("pause");
}