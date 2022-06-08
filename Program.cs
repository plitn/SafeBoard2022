using System;
using System.Collections.Generic;

namespace Kaspersky.SafeBoard
{
    // comments are in english because task is in english
    internal static class Program
    {
        // stack made for our directory
        private static Stack<string> paths;
        private static List<string> ops;
        private static void Main()
        {
            paths = new Stack<string>();
            /*
             * I don't know if I have to get commands from user's input so I'm using constant array of commands
             * also it says "You are given a list of strings ops" so it is constant
             */
            string[] cmd = {"d1/", "d2/", "../", "d21/", "./"};
            // using list here because it says "You are given a LIST of strings ops"
            ops = new List<string>(cmd);
            /*
             * how it works?
             * because we cen only move to the child directory we can use stack
             * directory tree has only one branch if we are using these commands
             * so if we are trying to get to the parent directory we can just pop child directory name
             * we don't have to store names of children because we can travel to directories using their names
             */
            foreach (var command in ops)
            {
                if (command.StartsWith("../"))
                {
                    if (paths.Count != 0)
                    {
                        paths.Pop();
                    }
                } else if (command.StartsWith("./"))
                {
                    // do nothing (remain in the same folder)
                }
                else
                {
                    paths.Push(command);
                }
            }
            // here we can just print size of our stack after all commands have been processed
            Console.WriteLine(paths.Count);
        }
    }
}