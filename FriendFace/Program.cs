using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace FriendFace
{
    internal class Program
    {
        public static bool menu1 = true;
        public static List<User> users = new List<User>
        {
            new User(1, "Stigh87", "Stigh", "stigh@email.com", 34),
            new User(2, "asdf", "asf", "afsh@email.com", 45),
            new User(3, "asdadfa", "Sdfghdh", "sgfhtdfghh@email.com", 12),
        };

        static void Main(string[] args)
        {
            Menu1();
        }

        private static void Menu1()
        {
            Console.Clear();
            while (menu1)
            {
                Console.WriteLine(@"Hei! " + users[0]._name);
                Console.WriteLine(@"
                1. Legg til en venn(GOOD LUCK)
                2. Fjerne en venn
                3. Se dine venner
                4. Se informasjon om en venn
                5. Opprett ny bruker");
                
                var command = Console.ReadKey(true).KeyChar;
                Menu2(command);
                menu1 = false;
            }
        }

        private static void Menu2(char command)
        {
            Console.Clear();
            if(command == '1') AddFriend();
            if(command == '2') ShowFriends(command); //sende med parameter: innlogget bruker
            if (command == '3') ShowFriends(command); //sende med parameter: innlogget bruker
            if (command == '4') ShowFriends(command); //sende med parameter: innlogget bruker
            if (command == '5') newUser(command); //sende med parameter: innlogget bruker
        }

        private static void newUser(char command)
        {
            var newId = users.Count + 1;
            Console.WriteLine("Skriv ønsket brukernavn:");
            var newUsername = Console.ReadLine();
            Console.WriteLine("Skriv E-post adresse:");
            var newMail = Console.ReadLine();
            Console.WriteLine("Hva er din alder?");
            var newAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hva er ditt fornavn?");
            var newName = Console.ReadLine();
            users.Add(new User(newId, newUsername, newName, newMail, newAge));
            Console.WriteLine("Trykk x for å gå tilbake");
            command = Console.ReadKey(true).KeyChar;
            if (command == 'x')
            {
                menu1 = true;
                Menu1();
            }
        }

        private static void ShowFriends(char keypress)
        {
            Console.Clear();
            for (var index = 0; index < users[0]._friends.Count; index++)
            {
                var friend = users[0]._friends[index];
                Console.WriteLine(index + " - " + friend._name);
            }

            if (keypress == '2')
            {
                RemoveFriend();
            }
            else if (keypress == '4')
            {
                showFriends();
            }
        }

        private static void showFriends()
        {
            Console.WriteLine("Hvilken venn vil du se informasjonen til?");
            var command = Console.ReadKey(true).KeyChar;
            if (command > 0)
            {
                var number = int.Parse(command.ToString());
                var index = number;

                var friend = users[0]._friends[index];
                Console.WriteLine(@$"{friend._id}
                                         {friend._username}
                                         {friend._name}  
                                         {friend._age}
                                         {friend._email}");
                Console.WriteLine("Trykk x for å gå tilbake eller r for å redigere: ");
                command = Console.ReadKey(true).KeyChar;
                if (command == 'x')
                {
                    menu1 = true;
                    Menu1();
                }
                else if (command == 'r')
                {
                    EditFriend(friend);
                }
            }

            else
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            char command;
            Console.WriteLine("Trykk 'x' for å gå tilbake");
            command = Console.ReadKey(true).KeyChar;
            if (command == 'x')
            {
                menu1 = true;
                Menu1();
            }
        }

        private static void EditFriend(User friend)
        {
            char command;
            var userIndex = users.FindIndex((x) => x._id == friend._id);

            Console.WriteLine("velg hvilken informsajon du skal endre (ID bytte er ikke tillatt)");
            command = Console.ReadKey(true).KeyChar;
            switch (command)
            {
                case '1':
                    command = '1';
                    editUsername(userIndex);
                    break;
                case '2':
                    command = '2';
                    editName(userIndex);
                    break;
                case '3':
                    command = '3';
                    editAge(userIndex);
                    break;
                case '4':
                    command = '4';
                    editMail(userIndex);
                    break;
                default:
                    Console.WriteLine("trykk på et gyldig nummer for å endre informasjon");
                    break;
            }
        }

        private static void RemoveFriend()
        {
            Console.WriteLine("Hvilken venn vil du fjerne?");
            var command = Console.ReadKey(true).KeyChar;
            if (command > 0)
            {
                var number = int.Parse(command.ToString());
                var index = number - 1;

                users[0].removeFriend(users[index]);
                Console.WriteLine(users[index]._name + " Removed");
                menu1 = true;
                Menu1();
            }
        }

        private static void editMail(int index)
        {
            Console.WriteLine("Skriv inn ny Epost: ");
            var newEmail = Console.ReadLine();
            users[index]._email = newEmail;
            menu1 = true;
            Menu1();
        }

        private static void editAge(int index)
        {
            Console.WriteLine("Skriv inn ny alder: ");
            var newAge = Convert.ToInt32(Console.ReadLine());
            users[index]._age = newAge;
            menu1 = true;
            Menu1();
        }

        private static void editName(int index)
        {
            Console.WriteLine("Skriv inn nytt navn: ");
            var newName = Console.ReadLine();
            users[index]._name = newName;
            menu1 = true;
            Menu1();
        }

        private static void editUsername(int index)
        {
            Console.WriteLine("Skriv inn nytt brukernavn: ");
            var newUsername = Console.ReadLine();
            users[index]._username = newUsername;
            menu1 = true;
            Menu1();
        }

        private static void AddFriend()
        {
            Console.Clear();
            Console.WriteLine("Hvilke person vil du legge til? Skriv ID nr. (Tilbake, trykk X)");
            foreach (var user in users)
            {   
                if (user._id != 1) Console.WriteLine($"ID:{user._id} - Username: {user._name}");
            }
            var command = Console.ReadKey(true).KeyChar;
            
            if (command > 0)
            {
                var number = int.Parse(command.ToString());
                var index = number - 1;
                
                users[0].addFriend(users[index]);
                Console.WriteLine(users[index]._name + " Added");
            }
            menu1 = true;
            Menu1();
        }
    }
}
