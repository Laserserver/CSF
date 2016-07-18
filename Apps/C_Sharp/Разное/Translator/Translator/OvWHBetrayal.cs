namespace Translator
{
  class OvWHBetrayal
  {
    public static string OvWHGetChar(string Input)
    {
      int Length = Input.Length;
      string Output = "";
      for (int i = 0; i < Length; i++)
      {
        switch (Input[i])
        {
          case 'q':
            Output += 'й';
            break;
          case 'w':
            Output += 'ц';
            break;
          case 'e':
            Output += 'у';
            break;
          case 'r':
            Output += 'к';
            break;
          case 't':
            Output += 'е';
            break;
          case 'y':
            Output += 'н';
            break;
          case 'u':
            Output += 'г';
            break;
          case 'i':
            Output += 'ш';
            break;
          case 'o':
            Output += 'щ';
            break;
          case 'p':
            Output += 'з';
            break;
          case '[':
            Output += 'х';
            break;
          case ']':
            Output += 'ъ';
            break;
          case 'a':
            Output += 'ф';
            break;
          case 's':
            Output += 'ы';
            break;
          case 'd':
            Output += 'в';
            break;
          case 'f':
            Output += 'а';
            break;
          case 'g':
            Output += 'п';
            break;
          case 'h':
            Output += 'р';
            break;
          case 'j':
            Output += 'о';
            break;
          case 'k':
            Output += 'л';
            break;
          case 'l':
            Output += 'д';
            break;
          case ';':
            Output += 'ж';
            break;
          case '\'':
            Output += 'э';
            break;
          case 'z':
            Output += 'я';
            break;
          case 'x':
            Output += 'ч';
            break;
          case 'c':
            Output += 'с';
            break;
          case 'v':
            Output += 'м';
            break;
          case 'b':
            Output += 'и';
            break;
          case 'n':
            Output += 'т';
            break;
          case 'm':
            Output += 'ь';
            break;
          case ',':
            Output += 'б';
            break;
          case '.':
            Output += 'ю';
            break;
          case '`':
            Output += 'ё';
            break;
          case 'Q':
            Output += 'Й';
            break;
          case 'W':
            Output += 'Ц';
            break;
          case 'E':
            Output += 'У';
            break;
          case 'R':
            Output += 'К';
            break;
          case 'T':
            Output += 'Е';
            break;
          case 'Y':
            Output += 'Н';
            break;
          case 'U':
            Output += 'Г';
            break;
          case 'I':
            Output += 'Ш';
            break;
          case 'O':
            Output += 'Щ';
            break;
          case 'P':
            Output += 'З';
            break;
          case '{':
            Output += 'Х';
            break;
          case '}':
            Output += 'Ъ';
            break;
          case 'A':
            Output += 'Ф';
            break;
          case 'S':
            Output += 'Ы';
            break;
          case 'D':
            Output += 'В';
            break;
          case 'F':
            Output += 'А';
            break;
          case 'G':
            Output += 'П';
            break;
          case 'H':
            Output += 'Р';
            break;
          case 'J':
            Output += 'О';
            break;
          case 'K':
            Output += 'Л';
            break;
          case 'L':
            Output += 'Д';
            break;
          case ':':
            Output += 'Ж';
            break;
          case '"':
            Output += 'Э';
            break;
          case 'Z':
            Output += 'Я';
            break;
          case 'X':
            Output += 'Ч';
            break;
          case 'C':
            Output += 'С';
            break;
          case 'V':
            Output += 'М';
            break;
          case 'B':
            Output += 'И';
            break;
          case 'N':
            Output += 'Т';
            break;
          case 'M':
            Output += 'Ь';
            break;
          case '<':
            Output += 'Б';
            break;
          case '>':
            Output += 'Ю';
            break;
          case '~':
            Output += 'Ё';
            break;
          case '/':
            Output += '.';
            break;
          case '&':
            Output += '?';
            break;
          case '?':
            Output += ',';
            break;
          default:
            Output += Input[i];
            break;
        }
      }
      return Output;
    }
  }
}
