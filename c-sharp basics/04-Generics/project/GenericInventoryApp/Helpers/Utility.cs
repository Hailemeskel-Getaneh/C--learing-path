using System;
using System.Collections.Generic;

namespace GenericInventoryApp.Helpers
{
    public static class Utility
    {
        public static void PrintAll<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}