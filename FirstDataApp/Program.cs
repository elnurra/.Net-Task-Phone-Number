using FirstDataApp.CRUD;
//using FirstDataApp.Models;
using FirstDataApp.Validation;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
    Menu:
        MainMenu();
        string inputByUser = Console.ReadLine();
        switch (inputByUser)
        {
            case "A" or "a":
                Console.Clear();
            Name:
                InputName();
                string name = Console.ReadLine();
                if (!Validation.NameUser(name))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name creating is empty pls input correctly: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Name;
                }
                Console.Clear();
            SurName:
                InputSurName();
                string surname = Console.ReadLine();
                if (!Validation.SurNameUser(surname))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Surname creating is empty pls input correctly: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto SurName;
                }
                Console.Clear();
            Mail:

                InputMail();
                string mail = Console.ReadLine();
                if (!Validation.Email(mail))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mail creating is empty or wrong pls input correctly: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Mail;
                }
                Console.Clear();
            Phone:
                InputPhone();
                string phone = Convert.ToString(Console.ReadLine());
                if (!Validation.PhoneNumber(phone))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Phone number creating is empty or wrong pls input correctly: " +
                        "\nPS: Lenght should be equal 12!");
                    Console.ForegroundColor = ConsoleColor.Green;

                    goto Phone;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;                   
                    BaseCRUD.UserAdd(name, surname, mail, BaseCRUD.Converter(phone));
                    Console.ForegroundColor = ConsoleColor.White;
                Minor:
                    MinorMenu();
                    string newInputUser = Console.ReadLine();
                    switch (newInputUser)
                    {
                        case "A" or "a":
                            Console.Clear();
                            goto Name;

                        case "M" or "m":
                            Console.Clear();
                            goto Menu;

                        default:
                            Console.Clear();
                            goto Minor;

                    }

                }
            case "L" or "l":
                ListMenu:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                             -------------------- LIST OF USERS --------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                BaseCRUD.ListUsers();
                UDMMenu:
                ListMenu();
                string updateUserById = Console.ReadLine();
                switch (updateUserById)
                {
                    case "U" or "u":
                        Console.Clear();
                        BaseCRUD.ListUsers();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\n                                                  Choose ID that will be UPDATED ");
                        Console.ForegroundColor = ConsoleColor.White;
                   
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (Validation.CheckerId(id))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("ID not found*");
                            Thread.Sleep(1000);
                            goto ListMenu;
                        }
                        else
                        {
                            Console.Clear();
                        UpdateName:
                            InputName();
                            string nameUpdate = Console.ReadLine();
                            if (!Validation.NameUser(nameUpdate))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Name creating is empty pls input correctly: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto UpdateName;
                            }
                            Console.Clear();
                        SurNameUpdate:
                            InputSurName();
                            string surnameUpdate = Console.ReadLine();
                           
                            if (!Validation.SurNameUser(surnameUpdate))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Surname creating is empty pls input correctly: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto SurNameUpdate;
                            }
                            Console.Clear();
                        MailUpdate:

                            InputMail();
                            string mailUpdate = Console.ReadLine();
                            if (!Validation.Email(mailUpdate))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Mail creating is empty or wrong pls input correctly: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto MailUpdate;
                            }
                            Console.Clear();
                            
                        PhoneUpdate:
                            InputPhone();
                            string phoneUpdate = Convert.ToString(Console.ReadLine());
                            if (!Validation.PhoneNumber(phoneUpdate))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Phone number creating is empty or wrong pls input correctly: ");
                                Console.ForegroundColor = ConsoleColor.Green;

                                goto PhoneUpdate;
                            }
                            else
                            {
                                SubmitMenu:
                                Console.WriteLine("Are you sure you want to make UPDATE to the records? Y/N (Yes/No) ");
                                string submit = Console.ReadLine();
                                switch (submit)
                                {
                                    case "Y" or "y":
                                        BaseCRUD.UpdateUsers(id, nameUpdate, surnameUpdate, mailUpdate, phoneUpdate);
                                        goto Menu;
                                        break;
                                        case "N" or "n":
                                        goto ListMenu;
                                    default:
                                        goto SubmitMenu;
                                        
                                }
                            }
                            break;
                        }
                        break;
                    case "D" or "d":
                        Console.Clear();
                        BaseCRUD.ListUsers();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("\n \nSelect an identifier to be removed from the database: ");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            int deleteId = Convert.ToInt32(Console.ReadLine());

                            if (Validation.CheckerId(deleteId))
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("ID not found*");
                                Thread.Sleep(1000);
                                goto ListMenu;
                            }
                            else
                            {
                                
                                Console.WriteLine("Are you sure you want to delete the selected ID? Y/N (Yes/No) " + "\n The id that will be deleted: " +  deleteId);

                                string submitDelete = Console.ReadLine();
                                switch (submitDelete)
                                {
                                    case "Y" or "y":
                                        BaseCRUD.DeleteUsers(deleteId);
                                        goto ListMenu;
                                        break;
                                        case "N" or "n":
                                            goto ListMenu;
                                    default:
                                        goto ListMenu;
                                        
                                }

                                
                                
                            }

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Write int value not string");
                        }
                        break;
                    case "M" or "m":
                        Console.Clear();
                        goto Menu;
                        
                    case "E" or "e":
                        Environment.Exit(0);
                        break;
                    default:
                        goto ListMenu;
                       
                }
                break;
            case "S" or "s":
                Console.Clear();
                BaseCRUD.ListUsers();
                Console.WriteLine("\n Enter in the search field:");
                string search = Console.ReadLine();
                Console.WriteLine("\n\n");
                BaseCRUD.Searcher(search);
                goto UDMMenu;

                
            case "E" or "e":
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                goto Menu;
                break;
        }
        
    }
    public static void InputName()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please write your name:");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void InputSurName()
    {
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please write your surname:");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void InputMail()
    {
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please write your mail:");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void InputPhone() {
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please write your phone:");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void MainMenu() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                             -------------------- TELEFON REHBERİ --------------------\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                                               Kullanıcı Ekleme İşlemi   => A\n" +
        "                                               Kullanıcı Listeleme       => L\n" +
        "                                               Kullanıcı Arama           => S\n" +
        "                                               Çıkmak İçin               => E");

    }

    public static void MinorMenu()
    {
        Console.WriteLine("                                               Yeni Kayıt Ekleme  => A\n" +
        "                                               Ana Menü  => M");
    }

    public static void ListMenu()
    {

        Console.WriteLine("------------------------------------------------------------------------------------------------------------------" +
            "\n\n                                               Kullanıcı Güncellen       => U  \n" +
            "                                               Kullanıcı Sil             => D\n" +
            "                                               Ana Menü                  => M\n" +
            "                                               Çıkmak İçin               => E");


    }
    








}




































