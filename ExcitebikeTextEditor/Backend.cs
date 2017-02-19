using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 03/26/2016
 */
namespace ExcitebikeTextEditor {
    class Backend {

        int textFlag = 0;

        public Backend() {

        }

        public void getText(string path, TextBox texboxname, int length, int offset) {

            string romCodeString = "";
            string excitebikeAsciiOut = "";
            string tempHexString = "";
            int x = 0;
            FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read);
            fileStream.Seek(offset, SeekOrigin.Begin);

            while (x < length) {
                romCodeString = fileStream.ReadByte().ToString("X");
                //if length is single digit add a 0 ( 1 now is 01)
                if (romCodeString.Length == 1) {
                    romCodeString = "0" + romCodeString;
                }
                tempHexString = romCodeString;

                decodeRomText(tempHexString);
                if (textFlag == 0) {
                    excitebikeAsciiOut += decodeRomText(tempHexString);
                }
                x++;

                texboxname.Text = excitebikeAsciiOut;
            }
            fileStream.Close();
        }

        public void updateROMText(string absoluteFilename, int length, TextBox textBox, int offset) {
            // TODO: Optimize, all of these steps are unneccesary
            string newEBString = textBox.Text;

            Console.WriteLine("newEBString: " + newEBString);

            newEBString = newEBString.PadRight(length);
            string hexReturn = "";
            string tempascii = "";
            string[] newEBStringArray = new string[length];
            byte[] newEBStringByteArray = new byte[length];
            int[] ebDecimal = new int[length];
            string[] ebFinal = new string[length];
            string[] ebs = new string[length];

            int x = 0;
            while (x < length) {
                newEBStringArray[x] = newEBString[x].ToString();
                tempascii = newEBStringArray[x];
                hexReturn += encodeRomText(tempascii);
                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length) {
                Console.WriteLine("i: " + i + " j: " + j + " length: " + length);
                ebs[i] = hexReturn[j].ToString() + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length) {
                ebDecimal[q] = int.Parse(ebs[q], System.Globalization.NumberStyles.HexNumber);
                ebFinal[q] = ebDecimal[q].ToString();
                newEBStringByteArray[q] = byte.Parse(ebFinal[q]);
                q++;
            }
            
            using (FileStream fileStream = new FileStream(@absoluteFilename, FileMode.Open, FileAccess.Write)) {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length) {
                    fileStream.WriteByte(newEBStringByteArray[q]);
                    q++;
                }
            }
        }

        private string decodeRomText(string tempHexString) {
            string excitebikeAscii = "";
            textFlag = 0;

            switch (tempHexString) {
                case "00":
                    excitebikeAscii += "0";
                    break;
                case "01":
                    excitebikeAscii += "1";
                    break;
                case "02":
                    excitebikeAscii += "2";
                    break;
                case "03":
                    excitebikeAscii += "3";
                    break;
                case "04":
                    excitebikeAscii += "4";
                    break;
                case "05":
                    excitebikeAscii += "5";
                    break;
                case "06":
                    excitebikeAscii += "6";
                    break;
                case "07":
                    excitebikeAscii += "7";
                    break;
                case "08":
                    excitebikeAscii += "8";
                    break;
                case "09":
                    excitebikeAscii += "9";
                    break;
                case "0A":
                    excitebikeAscii += "A";
                    break;
                case "0B":
                    excitebikeAscii += "B";
                    break;
                case "0C":
                    excitebikeAscii += "C";
                    break;
                case "0D":
                    excitebikeAscii += "D";
                    break;
                case "0E":
                    excitebikeAscii += "E";
                    break;
                case "0F":
                    excitebikeAscii += "F";
                    break;
                case "10":
                    excitebikeAscii += "G";
                    break;
                case "11":
                    excitebikeAscii += "H";
                    break;
                case "12":
                    excitebikeAscii += "I";
                    break;
                case "13":
                    excitebikeAscii += "J";
                    break;
                case "14":
                    excitebikeAscii += "K";
                    break;
                case "15":
                    excitebikeAscii += "L";
                    break;
                case "16":
                    excitebikeAscii += "M";
                    break;
                case "17":
                    excitebikeAscii += "N";
                    break;
                case "18":
                    excitebikeAscii += "O";
                    break;
                case "19":
                    excitebikeAscii += "P";
                    break;
                case "1A":
                    excitebikeAscii += "Q";
                    break;
                case "1B":
                    excitebikeAscii += "R";
                    break;
                case "1C":
                    excitebikeAscii += "S";
                    break;
                case "1D":
                    excitebikeAscii += "T";
                    break;
                case "1E":
                    excitebikeAscii += "U";
                    break;
                case "1F":
                    excitebikeAscii += "V";
                    break;
                case "20":
                    excitebikeAscii += "W";
                    break;
                case "21":
                    excitebikeAscii += "X";
                    break;
                case "22":
                    excitebikeAscii += "Y";
                    break;
                case "23":
                    excitebikeAscii += "Z";
                    break;
                case "26":
                    excitebikeAscii += "*";
                    break;
                case "3A":
                    excitebikeAscii += "©";
                    break;
                case "79":
                    excitebikeAscii += "#";
                    break;
                case "F8":
                    excitebikeAscii += "=";
                    break;
                case "F9":
                    excitebikeAscii += "'";
                    break;
                case "FA":
                    excitebikeAscii += "!";
                    break;
                case "FB":
                    excitebikeAscii += ":";
                    break;
                case "FC":
                    excitebikeAscii += " ";
                    break;
                default:
                    excitebikeAscii += " ";
                    textFlag = 1;
                    break;
            }

            return excitebikeAscii;
        }

        public string encodeRomText(string tempascii) {
            string excitebikeHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii) {
                case "0":
                    excitebikeHex += "00";
                    break;
                case "1":
                    excitebikeHex += "01";
                    break;
                case "2":
                    excitebikeHex += "02";
                    break;
                case "3":
                    excitebikeHex += "03";
                    break;
                case "4":
                    excitebikeHex += "04";
                    break;
                case "5":
                    excitebikeHex += "05";
                    break;
                case "6":
                    excitebikeHex += "06";
                    break;
                case "7":
                    excitebikeHex += "07";
                    break;
                case "8":
                    excitebikeHex += "08";
                    break;
                case "9":
                    excitebikeHex += "09";
                    break;
                case "A":
                    excitebikeHex += "0A";
                    break;
                case "B":
                    excitebikeHex += "0B";
                    break;
                case "C":
                    excitebikeHex += "0C";
                    break;
                case "D":
                    excitebikeHex += "0D";
                    break;
                case "E":
                    excitebikeHex += "0E";
                    break;
                case "F":
                    excitebikeHex += "0F";
                    break;
                case "G":
                    excitebikeHex += "10";
                    break;
                case "H":
                    excitebikeHex += "11";
                    break;
                case "I":
                    excitebikeHex += "12";
                    break;
                case "J":
                    excitebikeHex += "13";
                    break;
                case "K":
                    excitebikeHex += "14";
                    break;
                case "L":
                    excitebikeHex += "15";
                    break;
                case "M":
                    excitebikeHex += "16";
                    break;
                case "N":
                    excitebikeHex += "17";
                    break;
                case "O":
                    excitebikeHex += "18";
                    break;
                case "P":
                    excitebikeHex += "19";
                    break;
                case "Q":
                    excitebikeHex += "1A";
                    break;
                case "R":
                    excitebikeHex += "1B";
                    break;
                case "S":
                    excitebikeHex += "1C";
                    break;
                case "T":
                    excitebikeHex += "1D";
                    break;
                case "U":
                    excitebikeHex += "1E";
                    break;
                case "V":
                    excitebikeHex += "1F";
                    break;
                case "W":
                    excitebikeHex += "20";
                    break;
                case "X":
                    excitebikeHex += "21";
                    break;
                case "Y":
                    excitebikeHex += "22";
                    break;
                case "Z":
                    excitebikeHex += "23";
                    break;
                case "*":
                    excitebikeHex += "26";
                    break;
                case "©":
                    excitebikeHex += "3A";
                    break;
                case "#":
                    excitebikeHex += "79";
                    break;
                case "=":
                    excitebikeHex += "F8";
                    break;
                case "'":
                    excitebikeHex += "F9";
                    break;
                case "!":
                    excitebikeHex += "FA";
                    break;
                case ":":
                    excitebikeHex += "FB";
                    break;
                case " ":
                    excitebikeHex += "FC";
                    break;
                default:
                    excitebikeHex += "FC";
                    break;
            }

            return excitebikeHex;
        }
    }
}
