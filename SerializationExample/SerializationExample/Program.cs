using System;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;
using HelperFunctions;
using System.Diagnostics;

//Binary File Handling
//https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute?view=netframework-4.7.1

//XML File Handling
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/how-to-read-object-data-from-an-xml-file
//https://docs.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization

namespace SerializationExample
{
    class Program
    {

        // Get the current directory.
        static string path = Directory.GetCurrentDirectory();
        static String binPath = path + "\\binary\\data.bin";
        static String xmlPath = path + "\\xml\\data.xml";

        static void Main(string[] args)
        {
            char choice = 'x';
            String menu = "";
            menu += "***************************************\n";
            menu += "       Serialization Main Menu\n";
            menu += "***************************************\n";
            menu += "a) Add a score to the Binary file\n";
            menu += "b) View scores from the Binary file\n";
            menu += "c) Delete Binary File and Data\n";
            menu += "d) Add a score to the XML file\n";
            menu += "e) View scores from the XML file\n";
            menu += "f) Delete XML File and Data\n";
            menu += "q) quit\n";
            menu += "\nMenu selection: ";
            do
            {
                Clear();
                choice = Char.ToLower(HelperClass.GetCharInput(menu));
                switch (choice)
                {
                    case 'a':
                        AddScoresBinaryWriter(GetScoresFromUser("B"));
                        break;
                    case 'b':
                        PrintObject(GetScoresBinaryReader());
                        break;
                    case 'c':
                        File.Delete(@binPath);
                        WriteLine("Binary Data Deleted.");
                        HelperClass.PressAnyKey();
                        break;
                    case 'd':
                        AddScoresXMLWriter(GetScoresFromUser("X"));
                        break;
                    case 'e':
                        PrintObject(GetScoresXMLReader());
                        break;
                    case 'f':
                        File.Delete(@xmlPath);
                        WriteLine("XML Data Deleted.");
                        HelperClass.PressAnyKey();
                        break;
                    case 'q':
                        WriteLine("Okay, goodbye.");
                        HelperClass.PressAnyKey();
                        break;
                    default:
                        Write("That is not a valid choice, ");
                        HelperClass.PressAnyKey();
                        choice = 'x';
                        break;
                }
            } while (choice != 'q');
        }

        static List<SportsScore> GetScoresFromUser(String which)
        {
            List<SportsScore> scoresToAdd = new List<SportsScore>();
            int id = GetCurrentId(which);
            char another = 'Y';
            do
            {
                Clear();
                WriteLine("Add a score:\n");
                SportsScore sc = new SportsScore();
                sc.Id = id;
                sc.SId = which + id;
                id++;
                sc.EventDate = HelperClass.GetStringInput("Enter the date of the event: ");
                sc.VisitorTeam = HelperClass.GetStringInput("Enter the visitor team name: ");
                sc.VisitorScore = HelperClass.GetPositiveIntegerInput("Enter the visitor team score: ");
                sc.HomeTeam = HelperClass.GetStringInput("Enter the home team name: ");
                sc.HomeScore = HelperClass.GetPositiveIntegerInput("Enter the home team score: ");
                scoresToAdd.Add(sc);
                do
                {
                    another = Char.ToUpper(HelperClass.GetCharInput("Add another score? (Y/N)"));
                    if ((another != 'Y') && (another != 'N'))
                        WriteLine("Please answer Y or N.");
                } while ((another != 'Y') && (another != 'N'));
            } while (another == 'Y');
            return scoresToAdd;
        }

        static void AddScoresBinaryWriter(List<SportsScore> scoreSet)
        {
            List<SportsScore> scList = GetScoresBinaryReader();
            scList.AddRange(scoreSet);
            //Opens a file and serializes the object list into it in binary format.
            Stream stream = File.Open(binPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, scList);
            stream.Close();
        }

        static List<SportsScore> GetScoresBinaryReader()
        {
            List<SportsScore> scList = new List<SportsScore>();
            try
            {
                //Opens file "data.dat" and de serializes the object from it.
                Stream stream = File.Open(binPath, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                scList = (List<SportsScore>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException fex)
            {
                Debug.Write(fex.Message);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return scList;
        }

        static void AddScoresXMLWriter(List<SportsScore> scoreSet)
        {
            List<SportsScore> scList = GetScoresXMLReader();
            scList.AddRange(scoreSet);
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<SportsScore>));
            var xmlFile = new System.IO.StreamWriter(xmlPath);
            writer.Serialize(xmlFile, scList);
            xmlFile.Close();
        }

        static List<SportsScore> GetScoresXMLReader()
        {
            List<SportsScore> scList = new List<SportsScore>();
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<SportsScore>));
                System.IO.StreamReader file = new System.IO.StreamReader(xmlPath);
                scList = (List<SportsScore>)reader.Deserialize(file);
                file.Close();
            }
            catch (FileNotFoundException fex)
            {
                Debug.Write(fex.Message);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return scList;
        }

        static void PrintObject(List<SportsScore> scores)
        {
            Clear();
            WriteLine("Scores:\n");
            if (scores.Count == 0)
            {
                WriteLine("There are no scores to display.\n");
            }
            else
            {
                scores.ForEach(score =>
                {
                    WriteLine(score.DisplayEntry());
                });
            }
            WriteLine();
            HelperClass.PressAnyKey();
        }

        static int GetCurrentId(String whichList)
        {
            List<SportsScore> scList = new List<SportsScore>();
            if (whichList == "B")
            {
                scList = GetScoresBinaryReader();
            }
            else
            {
                scList = GetScoresXMLReader();
            }
            if (scList.Count == 0)
            {
                return 1;
            }
            else
            {
                return scList[scList.Count - 1].Id + 1;
            }
        }

    }
}
