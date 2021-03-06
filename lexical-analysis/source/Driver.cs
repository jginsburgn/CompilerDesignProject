/*
Authors:
 - Gad Levy A01017986
 - Jonathan Ginsburg A01021617
 - Pablo de la Mora A01020365
*/

using System;
using System.IO;
using System.Text;

namespace Int64 {

    public class Driver {

        const string VERSION = "0.0";

        //-----------------------------------------------------------
        static readonly string[] ReleaseIncludes = {
            "Lexical analysis"
        };

        //-----------------------------------------------------------
        void PrintAppHeader() {
            Console.WriteLine("Int64 lexical analyzer " + VERSION);
            Console.WriteLine("GJP."
            );
        }

        //-----------------------------------------------------------
        void PrintReleaseIncludes() {
            Console.WriteLine("Included in this release:");
            foreach (var phase in ReleaseIncludes) {
                Console.WriteLine("   * " + phase);
            }
        }

        //-----------------------------------------------------------
        void Run(string[] args) {

            PrintAppHeader();
            Console.WriteLine();
            PrintReleaseIncludes();
            Console.WriteLine();

            if (args.Length != 1) {
                Console.Error.WriteLine(
                    "Please specify the name of the input file.");
                Environment.Exit(1);
            }

            try {
                var inputPath = args[0];
                var input = File.ReadAllText(inputPath);

                Console.WriteLine(String.Format(
                    "===== Tokens from: \"{0}\" =====", inputPath)
                );
                var count = 1;
                foreach (var tok in new Scanner(input).Start()) {
                    Console.WriteLine(String.Format("[{0}] {1}",
                                                    count++, tok)
                    );
                }

            } catch (FileNotFoundException e) {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }

        //-----------------------------------------------------------
        public static void Main(string[] args) {
            new Driver().Run(args);
        }
    }
}
