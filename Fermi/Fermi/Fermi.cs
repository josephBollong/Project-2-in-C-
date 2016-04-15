using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fermi {
    class Fermi {
        private int first;
        private int second;
        private int third;
        private Random rand = new Random();
        private int guesses;

        private String answer;

        private List<Int32> history = new List<Int32>();

        public Fermi() {
            reset();
        }
        public int getGuesses() {
            return guesses;
        }
        public String getAnswer() {
            return answer;
        }

        public void reset() {

            guesses = 0;
            first = getRandNum();
            second = getRandNum();
            third = getRandNum();

            SortedSet<int> _vals = new SortedSet<int>();
            _vals.Add(first);
            _vals.Add(second);
            _vals.Add(third);

            if (_vals.Count != 3) {
                reset();
            } else {

                history.Clear();
                answer = "ANSWER: " + first + " " + second + " " + third;
            }

            
        }
        private int getRandNum() {
            int num = rand.Next(10);
            return num;
        }


        public String guess(int num1, int num2, int num3) {
            String output = "";

            int guess = (num1 * 100) + (num2 * 10) + num3;
            
            if (history.Contains(guess)) {
                return null;
            }
            history.Add(guess);
            int nanoCounter = 3;
            int firstNum = first;
            int secondNum = second;
            int thirdNum = third;

            
            if (num1 == firstNum) {
            output += "Fermi ";
                firstNum = -1;
                nanoCounter--;
            }
            if (num2 == secondNum) {
            output += "Fermi ";
                secondNum = -1;
                nanoCounter--;
            }
            if (num3 == thirdNum) {
            output += "Fermi ";
                thirdNum = -1;
                nanoCounter--;
            }

            
            if (num1 == secondNum || num1 == thirdNum) {
            output += "Pico ";
                nanoCounter--;
            }
            if (num2 == firstNum || num2 == thirdNum) {
            output += "Pico ";

                nanoCounter--;
            }
            if (num3 == firstNum || num3 == secondNum) {
            output += "Pico ";
                nanoCounter--;
            }

            
            for (int n = 0; n < nanoCounter; n++) {
            output += "Nano ";
            }

            
            guesses++;

            
            return output.Substring(0, output.Length - 1);

        }
        public Boolean gameOverCheck(String _output) {
            return _output.ToLower().Contains("fermi fermi fermi");
        }
    }
}
