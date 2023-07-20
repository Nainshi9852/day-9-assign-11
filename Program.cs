using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_9_assign_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of LargeDataCollection and populating it with some initial data.
            using (LargeDataCollection collection = new LargeDataCollection(12,78,55,43,120,654))
            {
                while (true)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1 - Add data");
                    Console.WriteLine("2 - Remove data");
                    Console.WriteLine("3 - Access data");
                    Console.WriteLine("4 - Quit");

                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter data to add: ");
                                if (int.TryParse(Console.ReadLine(), out int newData))
                                {
                                    collection.Add(newData);
                                    Console.WriteLine("Data added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                                }
                                break;
                            case 2:
                                Console.Write("Enter data to remove: ");
                                if (int.TryParse(Console.ReadLine(), out int dataToRemove))
                                {
                                    collection.Remove(dataToRemove);
                                    Console.WriteLine("Data removed successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                                }
                                break;
                            case 3:
                                Console.Write("Enter the index to access data: ");
                                if (int.TryParse(Console.ReadLine(), out int index))
                                {
                                    try
                                    {
                                        Console.WriteLine("Data at index " + index + ": " + collection.GetElement(index));
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("Invalid index. Please enter a valid index.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                                }
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                        //Display the entire collection after every operation.
                        Console.WriteLine("Current Collection");
                        for (int i = 0; i < collection.GetElementCount(); i++)
                        {
                            Console.Write(collection.GetElement(i) + " ");
                        }
                        Console.WriteLine("\n");
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option number.");
                    }

                   Console.WriteLine();
                }
            } // Dispose will be called automatically when the 'using' block ends.

            // The LargeDataCollection object is disposed of now, and resources are released.
        }
    }
}
