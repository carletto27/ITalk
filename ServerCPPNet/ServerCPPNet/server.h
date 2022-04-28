#pragma once
#include <winsock2.h>
#include <map>

#undef UNICODE
#define WIN32_LEAN_AND_MEAN
#pragma comment (lib, "ws2_32.lib")

using namespace std;


class server
{


public:
	SOCKET start();
	fd_set acceptation(SOCKET ListenSocket, fd_set master);
	int scelta(char buf[4096], SOCKET client, int idcl , map <int, SOCKET> associazione);
	fd_set close(SOCKET ListenSocket, fd_set master);



};

