#include "server.h"
#include <iostream>
#include <WS2tcpip.h>
#include <string>
#include <sstream>
#include <windows.h>
#include <winsock2.h>
#include <stdlib.h>
#include <stdio.h>
#include <Windows.h>
#include <map>
#include <list>
#include <ctime>
#include <chrono>
#include <C:/Program Files/MySQL/MySQL Server 8.0/include/mysql.h>

#pragma comment(lib, "C:/Program Files/MySQL/MySQL Server 8.0/lib/libmysql.lib")

using sysclock_t = std::chrono::system_clock;

MYSQL* conn;
MYSQL* conn1;
int version = 1;

#undef UNICODE
#define WIN32_LEAN_AND_MEAN
#pragma comment (lib, "ws2_32.lib")

using namespace std;

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "4404"

//CAMBIARE IL SEGUENTE CAMPO IN BASE ALLA PASSWORD DEL DB
#define PASSWORD "carletto27"

string timestamp() {
	time_t now = sysclock_t::to_time_t(sysclock_t::now());

	char buf[16] = { 0 };
	strftime(buf, sizeof(buf), "%Y-%m-%d", std::localtime(&now));
	return string(buf);

}


bool is_number(string& s)
{
	string::const_iterator it;
	for (it = s.begin(); it != s.end(); it++) {
		if (isdigit(*it) == false) {
			return false;
		}
	}
	return true;
}


int registrazione(string messaggio, SOCKET client, int idcl) {

	int mem1 = 0, mem2 = 0, mem3 = 0, mem4 = 0, mem5 = 0;
	string nome, cognome, email, pass, ip;

	//id3,nomeCarlo,cognomeLentini,
	for (int i = 8; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			nome.push_back(carattere);
		}
		else {
			mem1 = i + 8;
			break;
		}
	}

	for (int i = mem1; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			cognome.push_back(carattere);
		}
		else {
			mem2 = i + 6;
			break;
		}
	}


	for (int i = mem2; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			email.push_back(carattere);
		}
		else {
			mem3 = i + 5;
			break;
		}
	}


	for (int i = mem3; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			pass.push_back(carattere);
		}
		else {
			mem4 = i + 3;
			break;
		}
	}


	for (int i = mem4; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			ip.push_back(carattere);
		}
		else {
			break;
		}
	}

	conn = mysql_init(NULL);
	conn1 = mysql_init(NULL);

	mysql_real_connect(conn1, "127.0.0.1", "root", PASSWORD, NULL, 3306, NULL, 0);
	mysql_query(conn1, "CREATE DATABASE IF NOT EXISTS progettoapl");
	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);
	string tempo = timestamp();
	mysql_query(conn, " create table IF NOT EXISTS utente(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),`ip` VARCHAR(45),`timestamp` VARCHAR(100) ,  PRIMARY KEY (`email`) ) ");
	string inserimento = "INSERT INTO utente VALUES('" + nome + "','" + cognome + "','" + email + "','" + pass + "','" + ip + "','" + tempo + "')";

	if (mysql_query(conn, inserimento.c_str())) {		
		mysql_close(conn);
		mysql_close(conn1);		
		string welcomeMsg = "1";
		send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
		return 1;
	}else{ 
		mysql_query(conn, "create table IF NOT EXISTS utenteLog(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),  `ip` VARCHAR(45), `id` VARCHAR(45),  PRIMARY KEY (`email`) ) ");
		string idcl1 = std::to_string(idcl);
		string inserimento1 = "INSERT INTO utenteLog VALUES('" + nome + "','" + cognome + "','" + email + "','" + pass + "','" + ip + "','" + idcl1 + "')";
		mysql_query(conn, inserimento1.c_str());
		mysql_close(conn);
		mysql_close(conn1);
		string welcomeMsg = "0";
		send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
		return 0;		
	}
	
}


int login(string messaggio,SOCKET client,int idcl) {

	string email, pass, ip;
	int mem1, mem2;
	for (int i = 9; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			email.push_back(carattere);
		}
		else {
			mem1 = i + 5;
			break;
		}
	}

	for (int i = mem1; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			pass.push_back(carattere);
		}
		else {
			mem2 = i + 3;
			break;
		}
	}

	for (int i = mem2; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			ip.push_back(carattere);
		}
		else {
			break;
		}
	}

	conn = mysql_init(NULL);
	conn1 = mysql_init(NULL);

	mysql_real_connect(conn1, "127.0.0.1", "root", PASSWORD, NULL, 3306, NULL, 0);
	version = mysql_get_server_version(conn1);
	mysql_query(conn1, "CREATE DATABASE IF NOT EXISTS progettoapl");

	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);
	version = mysql_get_server_version(conn);

	string ricerca = "select * from utente where email = \"" + email + "\" and  password = \"" + pass + "\"";

	mysql_query(conn, "create IF NOT EXISTS table utente(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),  `ip` VARCHAR(45),`timestamp` VARCHAR(100) , PRIMARY KEY (`email`) ) ");

	mysql_query(conn, ricerca.c_str());
	MYSQL_RES* result = mysql_store_result(conn);
	int numRighe = result->row_count;
	if (numRighe == 0) {
		string welcomeMsg = "1";
		send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
		return 1;
		mysql_close(conn);
	    mysql_close(conn1);
	}
	else {
		mysql_query(conn, "create table IF NOT EXISTS utenteLog(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),  `ip` VARCHAR(45), `id` VARCHAR(45),  PRIMARY KEY (`email`) ) ");
		mysql_query(conn, ricerca.c_str());
		MYSQL_RES* result = mysql_store_result(conn);
		int num_fields = mysql_num_fields(result);

		string prova[] = { "", "" , "", "", "", ""};

		MYSQL_ROW row;
		while ((row = mysql_fetch_row(result)))
		{
			for (int i = 0; i < num_fields; i++)
			{
				prova[i] = row[i] ? row[i] : "NULL";
			}
		}

		string idcl1 = std::to_string(idcl);

		string inserimento1 = "INSERT INTO utenteLog VALUES('" + prova[0] + "','" + prova[1] + "','" + prova[2] + "','" + prova[3] + "','" + prova[4] + "','" + idcl1 + "')";
		if (mysql_query(conn, inserimento1.c_str())) {
			//mysql_close(conn);
			//mysql_close(conn1);
			string welcomeMsg = "1";
			send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
		}
		else {
			string welcomeMsg = "0";
			send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
		}

		mysql_close(conn);
		mysql_close(conn1);
		return 0;
	}
}


int chiusura(string messaggio, SOCKET client, map  <int, SOCKET> associazione) {
	string email;

	for (int i = 3; i < messaggio.length(); i++) {
		char carattere = messaggio[i];		
			email.push_back(carattere);			
	}

	conn = mysql_init(NULL);

	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);

	string ricerca = "delete from utenteLog where email = \"" + email + "\"";

	if (mysql_query(conn, ricerca.c_str())) {
		mysql_close(conn);
		exit(1);
	}
	mysql_close(conn);
	return 0;
}


void invioMsg(string messaggio, map  <int, SOCKET> associazione, SOCKET client) {

	
		int idcl;
		string idcl1;
		string msg;
		int memo;

		for (int i = 8; i < messaggio.length(); i++) {
			char carattere = messaggio[i];
			if (carattere != ',') {
				idcl1.push_back(carattere);
			}
			else {
				memo = i + 1;
				break;
			}
		}


		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];
			msg.push_back(carattere);
		}

		string msg1 = "0," + msg;

		bool verifica = is_number(idcl1);

		if(verifica == true){
		idcl = stoi(idcl1);
		map <int, SOCKET>::iterator it;

		bool var = false;

		for (it = associazione.begin(); it != associazione.end(); it++)
		{
			if (it->first == idcl) {
				send(it->second, msg1.c_str(), msg1.size() + 1, 0);
				var = true;
			}
		}
		if (var == false) {
			string msg3 = "2,";
			send(client, msg3.c_str(), msg3.size() + 1, 0);
		}
	}

	else {
		string msg3 = "2,";
		send(client, msg3.c_str(), msg3.size() + 1, 0);
	}

}


void mostraTab(string messaggio, SOCKET client) {
	string email;

	for (int i = 4; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			email.push_back(carattere);
		}
		else {
			break;
		}
	}

	conn = mysql_init(NULL);
	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);
	string ricerca = "select * from utenteLog where email != \"" + email + "\"";
	mysql_query(conn, ricerca.c_str());
	MYSQL_RES* result = mysql_store_result(conn);

	int num_fields = mysql_num_fields(result);
	MYSQL_ROW row;
	string invio = "1,";

	while ((row = mysql_fetch_row(result)))
	{
	
		for (int i = 0; i < num_fields; i++)
		{
			invio += row[i];
			if (i == 5) {
				invio += "/";
			}
			else {
				invio += ",";
			}
		}
	}

	mysql_free_result(result);
	mysql_close(conn);
	
	send(client, invio.c_str(), invio.size() + 1, 0);
}


void eliminazione(string messaggio) {

	string email;

	for (int i = 3; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		email.push_back(carattere);
	}

	conn = mysql_init(NULL);
	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);
	string ricerca = "delete from utente where email = \"" + email + "\"";
	string ricerca1 = "delete from utenteLog where email = \"" + email + "\"";
	mysql_query(conn, ricerca.c_str());
	mysql_query(conn, ricerca1.c_str());
	mysql_close(conn);

}


void modifica(string messaggio) {
	conn = mysql_init(NULL);
	mysql_real_connect(conn, "127.0.0.1", "root", PASSWORD, "progettoapl", 3306, NULL, 0);
	version = mysql_get_server_version(conn);

	string id1 = "";
	string email;
	int memo;

	for (int i = 6; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		
		if (carattere != ',') {
			id1.push_back(carattere);
		}
		else {
			break;
		}
	}

	for (int i = 8; i < messaggio.length(); i++) {
		char carattere = messaggio[i];

		if (carattere != ',') {
			email.push_back(carattere);
		}
		else {
			memo = i + 1;
			break;
		}
	}

	int id = stoi(id1);
	
	if (id == 0) {		
		string nome;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				nome.push_back(carattere);
			}
			else {
				break;
			}
		}
		string up1 = "UPDATE utenteLog set nome = \"" + nome + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set nome = \"" + nome + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());	
	}
	else if (id == 1) {
		string cognome;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				cognome.push_back(carattere);
			}
			else {
				break;
			}
		}

		string up1 = "UPDATE utenteLog set cognome = \"" + cognome  + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set cognome = \"" +  cognome + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());

	}
	else if (id == 2) {

		string pass;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				pass.push_back(carattere);
			}
			else {
				break;
			}
		}

		string up1 = "UPDATE utenteLog set password = \"" + pass + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set password = \"" + pass + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());
	}
	else if (id == 3) {
		string nome;
		string cognome;
		int memo1;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				nome.push_back(carattere);
			}
			else {
				memo1 = i + 1;
				break;
			}
		}

		for (int i = memo1; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				cognome.push_back(carattere);
			}
			else {
				break;
			}
		}


		string up1 = "UPDATE utenteLog set nome = \"" + nome + "\", cognome = \"" + cognome + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set nome = \"" + nome + "\", cognome = \"" + cognome + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());


	}
	else if (id == 4) {
		string nome;
		string pass;
		int memo1;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				nome.push_back(carattere);
			}
			else {
				memo1 = i + 1;
				break;
			}
		}

		for (int i = memo1; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				pass.push_back(carattere);
			}
			else {
				break;
			}
		}

		string up1 = "UPDATE utenteLog set nome = \"" + nome + "\", password = \"" + pass + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set nome = \"" + nome + "\", password = \"" + pass + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());

	}
	else if (id == 5) {	
		string cognome;
		string pass;
		int memo1;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				cognome.push_back(carattere);
			}
			else {
				memo1 = i + 1;
				break;
			}
		}

		for (int i = memo1; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				pass.push_back(carattere);
			}
			else {
				break;
			}
		}
		string up1 = "UPDATE utenteLog set cognome = \"" + cognome + "\", password = \"" + pass + "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set cognome = \"" + cognome + "\", password = \"" + pass + "\" where email = \"" + email + "\"";
		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());
	}
	else if (id == 6) {
		string nome;
		string cognome;
		string pass;
		int memo1;
		int memo2;

		for (int i = memo; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				nome.push_back(carattere);
			}
			else {
				memo1 = i + 1;
				break;
			}
		}

		for (int i = memo1; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				cognome.push_back(carattere);
			}
			else {
				memo2 = i + 1;
				break;
			}
		}

		for (int i = memo2; i < messaggio.length(); i++) {
			char carattere = messaggio[i];

			if (carattere != ',') {
				pass.push_back(carattere);
			}
			else {
				break;
			}
		}

		string up1 = "UPDATE utenteLog set nome = \"" + nome + "\", cognome = \"" + cognome + "\", password = \"" +pass+ "\" where email = \"" + email + "\"";
		string up2 = "UPDATE utente set nome = \"" + nome + "\", cognome = \"" + cognome + "\", password = \"" + pass + "\" where email = \"" + email + "\"";

		mysql_query(conn, up1.c_str());
		mysql_query(conn, up2.c_str());
	}
	

	mysql_close(conn);
}


SOCKET server::start() {
	
	WSADATA wsaData;
	int iResult;
	SOCKET ListenSocket = INVALID_SOCKET;
	SOCKET ClientSocket = INVALID_SOCKET;
	struct addrinfo* result = NULL;
	struct addrinfo hints;

	char recvbuf[DEFAULT_BUFLEN];
	int recvbuflen = DEFAULT_BUFLEN;

	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	iResult = getaddrinfo("127.0.0.1", DEFAULT_PORT, &hints, &result);

	ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);

	iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);

	freeaddrinfo(result);

	iResult = listen(ListenSocket, SOMAXCONN);

	return ListenSocket;
}


fd_set server::acceptation(SOCKET ListenSocket, fd_set master) {
	SOCKET client = accept(ListenSocket, nullptr, nullptr);	
	FD_SET(client, &master);
	return master;
}


int server::scelta(char buf[4096], SOCKET client, int idcl, map  <int, SOCKET> associazione) {

	string messaggio;
	messaggio.append(buf);

	string messaggio1;
	messaggio1.append(buf);

	char chars[] = { 'Ì', '\x1','\"','{', '}',':'};
	for (unsigned int i = 0; i < sizeof(chars); ++i)
	{
		messaggio.erase(remove(messaggio.begin(), messaggio.end(), chars[i]), messaggio.end());
	}

	string id1;
	int mem;

	for (int i = 2; i < messaggio.length(); i++) {
		char carattere = messaggio[i];
		if (carattere != ',') {
			id1.push_back(carattere);
		}
		else {
			mem = i + 5;
			break;
		}
	}
	int id;
	id = stoi(id1);

	switch (id) {
	case 0:
		registrazione(messaggio, client, idcl);
		break;
	case 1:
		 login(messaggio, client, idcl);
		break;
	case 2:
		 chiusura(messaggio, client, associazione);
		 break;
	case 3:		
		invioMsg(messaggio1, associazione, client);
		break;
	case 4:
		mostraTab(messaggio, client);
		break;
	case 5:
		eliminazione(messaggio);
		break;
	case 6:
		modifica(messaggio);
		break;
	}
	
	return 0;

}

	
fd_set server::close(SOCKET ListenSocket, fd_set master) {

	FD_CLR(ListenSocket, &master);
	closesocket(ListenSocket);

	while (master.fd_count > 0)
	{
		SOCKET sock = master.fd_array[0];

		FD_CLR(sock, &master);
		closesocket(sock);
	}
	return master;
}
