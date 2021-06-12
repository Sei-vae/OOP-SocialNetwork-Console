using SocialNetworkED20210304;
using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialesNetzwerk sn = new SocialesNetzwerk();
            Person p = new Person();
            Person cUser;

            do
            {
                bool _logedin = false;

                Console.WriteLine("#######################");
                Console.WriteLine("To Log in press <1>....");
                Console.WriteLine("To create an account press <2>....");
                Console.WriteLine("To return all Messages press <3>....");
                Console.WriteLine("To return all Users press <4>....");
                Console.WriteLine("To return all Messages as a single string press <5>....");
                Console.WriteLine("To change your password press <6>....");
                Console.WriteLine("<<<ADMIN ONLY>>> To return all User with Username and Password press <7>....");
                Console.WriteLine("#######################");

                ConsoleKey _input = Console.ReadKey().Key;

                switch (_input)
                {
                    // Log in
                    case ConsoleKey.D1:
                        Console.WriteLine("\n\rRedirected to LogIn\n\r");
                        _logedin = false;
                        _logedin = sn.LogIn();
                        if (_logedin)
                        {
                            Console.WriteLine("You have successfuly loged in." + Environment.NewLine);
                        }
                        cUser = sn._cUsername;
                        break;

                    //  Create an Account
                    case ConsoleKey.D2:
                        Console.WriteLine("\n\rRedirected to Registration\n\r");
                        sn.HinzufuegenMitglieder();
                        _logedin = true;
                        cUser = sn._cUsername;
                        break;

                    // Return all Messages
                    case ConsoleKey.D3:
                        Console.WriteLine("\n\rReturning all Messages\n\r");
                        sn.GetAlleMessages();
                        break;

                    // Return all Users
                    case ConsoleKey.D4:
                        Console.WriteLine("\n\rReturning all Users\n\r");
                        sn.ReturnAllUsers();
                        break;
                        
                    // Return all Messages as a single String
                    case ConsoleKey.D5:
                        Console.WriteLine("\n\rReturning all Messages as a single String\n\r");
                        string _allmessages = sn.GetAlleNachrichten();
                        Console.WriteLine(_allmessages);
                        break;

                        // Change your Password
                    case ConsoleKey.D6:
                        Console.WriteLine("\n\rRedirected to Change Password\n\r");
                        _logedin = false;
                        _logedin = sn.LogIn();
                        cUser = sn._cUsername;
                        bool passwordChanged = false;
                        if (_logedin)
                        {
                            passwordChanged = sn.ChangePassword(cUser);
                            if (passwordChanged == false) { Console.WriteLine("You have successfully change your Password." + Environment.NewLine); }
                            else { Console.WriteLine("Password not changed." + Environment.NewLine); }
                        }
                        else { Console.WriteLine("Login was not successful." + Environment.NewLine); }
                        if (_logedin) { Console.WriteLine("You are still Loged in." + Environment.NewLine); }
                        break;
                    
                    // Return all User with Username and Password.
                    case ConsoleKey.D7:
                        Console.WriteLine("\n\rReturning all Users with their passwords" + Environment.NewLine);
                        sn.ReturnAllUsersAndPassword();
                        break;
                }

                if (_logedin)
                {
                    do
                    {   //#Loged in Menu
                        Console.WriteLine("\r\nHow do you want to continue? \r\nPress <1> to send a message....\r\nPress <2> to like a message....\r\nPress <3> to log out....");
                        try
                        {
                            int _readkey = Convert.ToInt32(Console.ReadLine());

                            if (_readkey == 1) {sn.HinzufuegenNachricht(); }

                            else if (_readkey == 2) { sn.HinzufuegenLike(); }

                            else if (_readkey == 3) { _logedin = false; }
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    } while (_logedin);

                }

                Console.WriteLine("\n\rPress <Enter> to continue....\n\rPress <Escape> to exit....\n\r#######################");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.ReadLine();
        }
    }
}
