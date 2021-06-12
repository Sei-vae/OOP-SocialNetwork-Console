using SocialNetwork;
using System;
using System.Collections.Generic;

namespace SocialNetworkED20210304
{
    class SocialesNetzwerk
    {
        private List<Nachricht> _nachrichtenListe = new List<Nachricht>();
        private List<Person> _mitgliederListe = new List<Person>();
        public Person _cUsername;

        public SocialesNetzwerk() { }

        private List<Person> GetAllUsers // property
        {
            get { return _mitgliederListe; }
            set { _mitgliederListe = value; }
        }

        public string HinzufuegenNachricht()//Could return <Nachricht>, not doing it tho
        {

            string uname = _cUsername.GetUsername;
            string _message;

            Console.WriteLine("\r\nInsert Message or FileName:\r\n ");
            _message = Console.ReadLine();
            
            if (_message.Length >= 4 &&(_message.Substring(_message.Length - 3).ToLower() == "png" || _message.Substring(_message.Length - 3).ToLower() == "jpg" || _message.Substring(_message.Length - 3).ToLower() == "gif"))
            {
                Bildnachricht Message = new Bildnachricht(uname, _message);
                //Message.getNachricht(); // Returns a "Nachricht" Type.
                _nachrichtenListe.Add(Message);
            }
            else
            {
                Textnachricht Message = new Textnachricht(uname, _message);
                //Message.getNachricht(Message); // Returns a "Nachricht" Type.
                _nachrichtenListe.Add(Message);
            }
            return null;
        }

        public string GetAlleNachrichten()//Returns all messages as a single string
        {
            string allmessages = "";
           
            foreach (Nachricht item in _nachrichtenListe)
            {
                allmessages = ($"{allmessages}|{item.getNachricht()}|");
            }

            return allmessages;
        }

        public string GetAlleMessages()//Returns nothing
        {
            int _pos = 1;
            foreach (Nachricht item in _nachrichtenListe)
            {
                string _type = item.GetType().ToString();
                string[] _typeArray = _type.Split('.');
                Console.WriteLine($"{_pos} : {item.GetUname} : {item.GetMessage} : {item.GetLikes} : {_typeArray[1]}");
                _pos = _pos + 1;
            }
            return null;
        }

        public string ReturnAllUsers()//Returns nothing
        {
            foreach (Person item in this.GetAllUsers) { Console.WriteLine($"First Name: {item.GetVorname}| Last Name:{item.GetNachname} | Username:{item.GetUsername}\n\r"); }
            return null;
        }

        public string ReturnAllUsersAndPassword()//Returns nothing
        {
            foreach (Person item in this.GetAllUsers)
            {
                Console.WriteLine($"First Name: {item.GetVorname}| Last Name:{item.GetNachname} | Username:{item.GetUsername} | Password:{item.GetAndSetPW}");
                Console.WriteLine(" ");
            }
            return null;
        }

        public bool LogIn()//Returns bool for verification
        {
            string _pw;
            string _uname;

            bool _verificationNotComp = true;
            bool _verificationComp = false;

            Console.WriteLine("#################################");
            Console.WriteLine("############Log In Page##########");
            Console.WriteLine("#################################");

            do
            {
                Console.WriteLine("Username: ");
                _uname = Console.ReadLine();
                Console.WriteLine("Password: ");
                _pw = Console.ReadLine();

                foreach (Person item in _mitgliederListe)
                {
                    if (item.GetUsername == _uname)
                    {
                        if (item.GetAndSetPW == _pw)
                        {
                            _cUsername = item;
                            _verificationNotComp = false;
                            break;
                        }
                        else
                        {
                            _verificationNotComp = true;
                        }
                    }


                }
                if (_verificationNotComp == true)
                {
                    Console.WriteLine("Username or Password was not correct." + Environment.NewLine + " Please try again. ");
                    Console.WriteLine("Press <Escape> to cancel the login...." + Environment.NewLine);

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }

            } while (_verificationNotComp);

            if (_verificationNotComp == false)
            {
                _verificationComp = true;
            }
            else
            {
                _verificationComp = false;
            }



            return _verificationComp;
        }

        public bool ChangePassword(Person cUser)//Returns bool for verification
        {
            string _pwNew;
            bool _verificationNotComp = false;

            do
            {
                Console.WriteLine("#################################");
                Console.WriteLine("######NEW PASSWORD Page#########");
                Console.WriteLine("#################################");
                string _uname = cUser.GetUsername;
                Console.WriteLine("New Password: ");
                _pwNew = Console.ReadLine();

                foreach (Person item in _mitgliederListe)
                {
                    if (item.GetUsername == _uname)
                    {
                        Person newMember = new Person(item.GetVorname, item.GetNachname, item.GetUsername, _pwNew);
                        _mitgliederListe.Remove(item);
                        _mitgliederListe.Add(newMember);
                        _verificationNotComp = false;
                        break;
                    }
                    else {_verificationNotComp = true;}
                }
                // bool = true = Not changed
                // bool = false = Changed

                if (_verificationNotComp == true)
                {
                    Console.WriteLine("Username or Password was not correct." + Environment.NewLine + " Please try again. ");
                    Console.WriteLine("Press <Escape> to cancel the login...." + Environment.NewLine);
                    if (Console.ReadKey().Key == ConsoleKey.Enter){break;}
                }
                else{_verificationNotComp = false;}
            } while (_verificationNotComp);
            return _verificationNotComp;
        }

        private string CreatePassword(string vname, string nname)//Returns pw (initial password)
        {
            string _pw;

            int lengthvname = vname.Length - 1;
            int lengthnname = nname.Length - 1;

            if (nname.Length >= 4)
            {
                if (vname.Length >= 4)
                {
                    _pw = $"{vname.Substring(0, 1).ToUpper()}{vname.Substring(1, 3).ToLower()}{nname.Substring(0, 1).ToUpper()}{nname.Substring(1, 3).ToLower()}";
                }
                else
                {

                    _pw = $"{vname.Substring(0, 1).ToUpper()}{vname.Substring(1, lengthvname).ToLower()}{nname.Substring(0, 1).ToUpper()}{nname.Substring(1, 3).ToLower()}";
                }
            }
            else
            {
                if (vname.Length >= 4)
                {
                    _pw = $"{vname.Substring(0, 1).ToUpper()}{vname.Substring(1, 3).ToLower()}{nname.Substring(0, 1).ToUpper()}{nname.Substring(1, lengthnname).ToLower()}";
                }
                else
                {

                    _pw = $"{vname.Substring(0, 1).ToUpper()}{vname.Substring(1, lengthvname).ToLower()}{nname.Substring(0, 1).ToUpper()}{nname.Substring(1, lengthnname).ToLower()}";
                }
            }

            return _pw;
        }

        public Person HinzufuegenMitglieder()//Could return <Person>, not doing it tho.
        {
            string uname;
            string vname;
            string nname;

            Console.WriteLine("#################################");
            Console.WriteLine("#########Create Account##########");
            Console.WriteLine("#################################");
            
            bool lenghtcheckNoPassed = true;

            // Need to Implenet Validation in another Class!

            do//Username length Check || Return bool = false if success
            {
                Console.WriteLine("Username: ");
                uname = Console.ReadLine();

                if (uname.Length >= 3)
                {
                    lenghtcheckNoPassed = false;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Username has to be atleast 3 Characters." + Environment.NewLine);
                    lenghtcheckNoPassed = true;
                }
            } while (lenghtcheckNoPassed);

            do
            {
                Console.WriteLine(Environment.NewLine + "First Name: ");
                vname = Console.ReadLine();

                if (vname.Length >= 3)
                {
                    lenghtcheckNoPassed = false;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "First Name has to be atleast 3 Characters." + Environment.NewLine);
                    lenghtcheckNoPassed = true;
                }
            } while (lenghtcheckNoPassed);

            do
            {
                Console.WriteLine(Environment.NewLine + "Last Name: ");
                nname = Console.ReadLine();

                if (nname.Length >= 3)
                {
                    lenghtcheckNoPassed = false;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Last Name has to be atleast 3 Characters." + Environment.NewLine);
                    lenghtcheckNoPassed = true;
                }
            } while (lenghtcheckNoPassed);

            
            string _pw = this.CreatePassword(nname, vname); //PW and Public shouldnt exist in the same line
            Console.WriteLine($"{Environment.NewLine}Your Password is: {_pw}.");
            Console.WriteLine($"{Environment.NewLine}You can change your Password in the Menu.");
            Person newMember = new Person(vname, nname, uname, _pw);

            _mitgliederListe.Add(newMember);
            _cUsername = newMember;
            return null;
        }

        public string HinzufuegenLike()//Returns nothing, could return like amount 
        {
            Console.WriteLine("\r\nWhich message do you want to like?\r\nInsert the <IndexNr> to continue....\r\n");
            int _pos = 1;
            foreach (Nachricht item in _nachrichtenListe)
            {
                Console.WriteLine($"{_pos} : {item.GetUname} : {item.GetMessage} : {item.GetLikes}");
                _pos = _pos + 1;
            }
            Console.WriteLine("\r\nInsert the <IndexNr>\r\n");
            _pos = Convert.ToInt32(Console.ReadLine()) - 1;
            int _likes = _nachrichtenListe[_pos].GiveLike();
            Console.WriteLine($"Message at <IndexNr> : {_pos} : Now has {_likes} Like");
            return null;
        }
    }
}
