import mysql.connector
import matplotlib.pyplot as plt
import numpy as np
import getpass
import sys



connessione1 = mysql.connector.connect(host = "localhost", user = "root", passwd = "carletto27")
cursore1 = connessione1.cursor()

connessione = mysql.connector.connect(host = "localhost", user = "root", passwd = "carletto27", database = "progettoapl")
cursore = connessione.cursor()

def totUtenti():
     connessione.commit()
     print("Gli utenti registrati sono i seguenti: ")
     cursore.execute("SELECT * from utente")
     risultati = cursore.fetchall()
     if(len(risultati) == 0):
         print("Nessun risultato")
     else:
         for i in risultati:
             print(i)
     print()     


def totUtentiByEmail(email):
     connessione.commit()
     print("La ricerca ha dato i seguenti risultati: ")
     cursore.execute("SELECT * from utente where email = '"+email + "'")
     risultati = cursore.fetchall()
     if(len(risultati) == 0):
         print("Nessun risultato")
     else:
          for i in risultati:
              print(i)         
     print()


def totUtentiOnline():
     connessione.commit()
     print("Gli utenti online sono i seguenti: ")
     cursore.execute("SELECT * from utenteLog")
     risultati = cursore.fetchall()
     if(len(risultati) == 0):
         print("Nessun risultato")
     else:
         for i in risultati:
             print(i)
     print() 


def numUtenti():
     connessione.commit()
     cursore.execute("SELECT * from utente")
     risultati = cursore.fetchall()
     print("Il numero di utenti registrati e' il seguente: " + str(len(risultati)))
     print() 


def numUtentiOnline():
     connessione.commit()
     cursore.execute("SELECT * from utenteLog")
     risultati = cursore.fetchall()
     print("Il numero di utenti online e' il seguente: " + str(len(risultati)))
     print()
     

def modNomeByEmail(nome,email):
     connessione.commit()
     cursore.execute("UPDATE utente set nome = '"+ nome + "' where email = '"+email+"'")
     connessione.commit()
     cursore.execute("UPDATE utentelog set nome = '"+ nome + "' where email = '"+email+"'")
     connessione.commit()
     print("Modifica effettuata")
     print()


def modCognomeByEmail(cognome,email):
     connessione.commit()
     cursore.execute("UPDATE utente set cognome = '"+ cognome + "' where email = '"+email+"'")
     connessione.commit()
     cursore.execute("UPDATE utentelog set cognome = '"+ cognome + "' where email = '"+email+"'")
     connessione.commit()
     print("Modifica effettuata")
     print()


def modPasswordByEmail(password,email):
     connessione.commit()
     cursore.execute("UPDATE utente set password = '"+ password + "' where email = '"+email+"'")
     connessione.commit()
     cursore.execute("UPDATE utentelog set password = '"+ password + "' where email = '"+email+"'")
     connessione.commit()
     print("Modifica effettuata")
     print()


def  UtentiRegistratiGrafico():
     connessione.commit()
     cursore.execute("SELECT Count(*) As NUtentiRegistrati, timestamp from utente group by timestamp order by timestamp")
     risultati = cursore.fetchall()
     
     if(len(risultati) == 0):
         print("Nessun risultato")
     else:
        for row in risultati:       
            #row[1] = timestamp
            #row[0] = numUtentiReg
            plt.plot(row[1], row[0], 'ro')
     
     plt.title("Numero Utenti Registrati Giornalmente")
     plt.xlabel('Giorni')
     plt.ylabel('Utenti Registrati')    
     plt.show()
     

def UtentiLoggatiVSRegistratiGrafico():
    connessione.commit()
    cursore.execute("SELECT *  from utente ")
    risultatiUR = cursore.fetchall()
    cursore.execute("SELECT *  from utenteLog ")
    risultatiUL = cursore.fetchall()
    fig = plt.figure()
    ax = fig.add_axes([0,0,1,1])
    ax.axis('equal')
    status = ['Utenti Online', 'Utenti Offline']
    utenti = [len(risultatiUL),len(risultatiUR)-len(risultatiUL)]
    #Le label sono le etichette
    #utenti = valori , autopct vogliamo in 100% con 1 cifra dopo la virgola
    ax.pie(utenti, labels = status,autopct='%1.2f%%')
    print("UR", len(risultatiUR) )
    print("UL ", len(risultatiUL))
    print("\n")
    plt.show()


def menu():
    scelta=-1
    while(scelta != 0):
        print("-------------------------MENU ADMIN-------------------------")
        print("0. Uscita")
        print("1. Visualizza tutti gli utenti registrati")
        print("2. Visualizza campi utente inserendo indirizzo e-mail")
        print("3. Visualizza utenti online")
        print("4. Visualizza Num. utenti registrati")
        print("5. Visualizza Num. utenti online")
        print("6. Modifica dati utente inserendo l'e-mail")
        print("7. Visualizza Utenti registrati giornalmente")
        print("8. Visualizza percentuali Utenti Loggati Rispetto utenti Registrati")
        print()
        try:
         scelta=int(input("Scegli un opzione: "))
        except(ValueError):
            print("Errore nell'inserimento dei dati per la scelta dell'opzione! ")
            continue
        if(scelta == 0):
            pass
        elif(scelta == 1):
            totUtenti()    
        elif(scelta == 2):
            email=input("Inserisci l'e-mail di cui vuoi vedere i campi fra gli utenti registrati: ")
            totUtentiByEmail(email)
        elif(scelta == 3):
            totUtentiOnline()  
        elif(scelta == 4):
            numUtenti()  
        elif(scelta == 5):
            numUtentiOnline() 
        elif(scelta == 6):
            connessione.commit()
            email=input("Inserisci l'e-mail di cui vuoi modificare un campo fra gli utenti registrati: ")
            cursore.execute("SELECT * from utente where email = '"+email + "'")
            risultati = cursore.fetchall()
            if(len(risultati) == 0):
                print("E-mail inserita non corretta")
            else:
                print("1. Modifica nome")
                print("2. Modifica cognome")
                print("3. Modifica password")
                scelta1=int(input("Scegli un opzione: "))
                if(scelta1 == 1):
                    nome=input("Inserisci il nuovo nome che vuoi inserire: ")
                    modNomeByEmail(nome,email)
                elif(scelta1 == 2):
                    cognome=input("Inserisci il nuovo cognome che vuoi inserire: ")
                    modCognomeByEmail(cognome,email)
                elif(scelta1 == 3):
                    password=input("Inserisci la nuova password che vuoi inserire: ")
                    modPasswordByEmail(password,email)
                else:
                    print("Scelta non corretta...")
        elif(scelta == 7):
            UtentiRegistratiGrafico()
        elif(scelta == 8):
            UtentiLoggatiVSRegistratiGrafico()
   
        
    print("-------------------------------------------------------------\n\n\n") 


scelta=-1
connessione1.commit()
cursore1.execute("CREATE DATABASE IF NOT EXISTS progettoapl")
connessione.commit()
cursore.execute("create table IF NOT EXISTS utente(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),`ip` VARCHAR(45),`timestamp` VARCHAR(100) ,  PRIMARY KEY (`email`) ) ") 
cursore.execute("create table IF NOT EXISTS utenteLog(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45),  `ip` VARCHAR(45), `id` VARCHAR(45),  PRIMARY KEY (`email`) )")
connessione1.commit()
connessione.commit()


while(scelta != 0):
    print("-------------------------ACCESSO ADMIN-------------------------")
    print("0. Uscita")
    print("1. Registrati")
    print("2. Login")
    print()
      
    try:
        scelta=int(input("Scegli un opzione: "))
    except(ValueError):
        print("Errore nell'inserimento dei dati per la scelta dell'opzione!")
        continue
    if(scelta == 0):
        pass
    elif(scelta == 1):
        nome=input("Inserisci il tuo nome: ")
        cognome=input("Inserisci il tuo cognome: ")
        email=input("Inserisci la tua email: ")
        password=getpass.getpass("Inserisci la tua password:")
        confPassword=getpass.getpass("Conferma la tua password:")
        if len(nome) == 0 or len(cognome) == 0 or len(email) == 0 or len(confPassword) == 0 or len(password) == 0 or email.find('@')==-1: 
            print("Riempi correttamente tutti i campi")
        else:
            connessione.commit()
            cursore.execute("create table IF NOT EXISTS utenteAdm(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45), PRIMARY KEY (`email`) ) ") 
            cursore.execute("SELECT * from utenteadm where email = '"+email + "'")
            risultati = cursore.fetchall()
            if(len(risultati) == 0):                      
                 cursore.execute ("INSERT INTO utenteadm VALUES('" + nome + "','" + cognome + "','" + email + "','" + password +  "')")
                 connessione.commit()
                 menu()
            else:
                print("Questa e-mail è gia stata utilizzata!")   
           
    elif(scelta == 2):
        email=input("Inserisci la tua email: ")
        password=getpass.getpass("Inserisci la tua password:")

        if len(email) == 0 or len(password)== 0 or email.find('@')==-1 :
            print("Riempi correttamente tutti i campi!")
        else:
            connessione.commit()
            cursore.execute("create table IF NOT EXISTS utenteAdm(`nome` VARCHAR(45),`cognome` VARCHAR(45), `email` VARCHAR(45),`password` VARCHAR(45), PRIMARY KEY (`email`) ) ") 
            cursore.execute("SELECT * from utenteadm where email = '"+email + "' and password = '" + password + "'")
            risultati = cursore.fetchall()
            if(len(risultati) == 0):
                print("Errore nell'accesso, nessun utente presente con queste credenziali")
            else:
                menu()

    else:
        print("Scelta non corretta...")
        print("-------------------------------------------------------------\n\n\n")

 
