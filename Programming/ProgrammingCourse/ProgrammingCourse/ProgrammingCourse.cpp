/*
Курсовая №10
Написать программу шифровки-дешифровки текстового файла при помощи перемешанного алфавита (символ с кодом М(i) 
(i – порядковый номер символа) заменяется символом с кодом (М(i)+К(i)) mod 256). К(i) – ключ шифра, случайные  
числа в диапазоне 0..255 (хранятся в отдельном файле)

Developed by Andrey Mishchuk
*/

#include <iostream>
#include <fstream>
#include <string>
#include <time.h>
#include <math.h>

using namespace std;



int data_encryption(string path)
{
    ifstream file;
    file.open(path);

    string line;

    if (!file.is_open())
    {
        cout << "Error with open the file" << path << endl;
    }
    else
    {

        while (!file.eof())
        {
            file >> line;
        }
    }

    ofstream key_file, cryptfile;
    string key_path = "key_file_" + path;
    key_file.open(key_path, ios::out);

    string cr_path = "cryptfile_" + path;
    cryptfile.open(cr_path, ios::out);

    if (key_file.is_open())
    {
        cout << "Key file for <" << path << "> has been created" << endl;
    }

    if (cryptfile.is_open())
    {
        cout << "The crypted code is in file <" << cr_path << ">" << endl;
    }

    srand(time(0));

    for (int i = 0; i < line.length(); i++)
    {
        int k = rand() % 255;
        unsigned char h = (unsigned char)(line[i] + k) % 256;
        key_file << k << endl;
        cryptfile << h;
    }

    key_file.close();
    cryptfile.close();
    return 0;
}

int data_decryption(string path, string key)
{
    ifstream file1, file2;
    string line; // Хранит зашифрованную строку
    int size = 0;
	

    file1.open(path);     
    if (!file1.is_open())
    {
        cout << "Error with open the file " << path << endl;
    }
    else
    {
        while (!file1.eof())
        {
            file1 >> line;
        }
    }
    file1.close();

    const int lsize = line.length();

    int* key_mas = new int[lsize];

    file2.open(key);

    if (!file2.is_open())
    {
        cout << "Error with open the file " << path << endl;
    }
    else
    {

        string str; 
        unsigned char temp;
        int i = 0;

        while (!file2.eof())
        {
            if (i < lsize)
            {
                file2 >> str;
                temp = (unsigned char)stoi(str);
                key_mas[i] = (int)temp;
                i++;
            }
            else
            {
                break;
            }
        }
    }
    file2.close();
	
	ofstream decryptfile;
    string key_path = "decryptfile_" + path;
    decryptfile.open(key_path, ios::out);
	if (!decryptfile.is_open())
    {
        cout << "Error with open the file " << path << endl;
    }
    else
    {
        unsigned char decrypted_str;

		for (int i = 0; i < line.length(); i++)
		{
			if (line[i] < key_mas[i])
			{
				decrypted_str = (unsigned char)((int)line[i] + 256 - key_mas[i]);
			}
			else
			{
				decrypted_str = (unsigned char)((int)line[i] - key_mas[i]);
			}
			decryptfile << decrypted_str;
		}
    }
	decryptfile.close();
    cout << endl;
    return 0;
}

int main(int argc, unsigned char* argv[])
{
    string path = "example.txt";
    string path_for_encrypted = "cryptfile_" + path;
    string path_for_keyfile = "key_file_" + path;

	int v;
	
	while(1)
	{
		cout << "\t|Encrypt-Decrpypt|\n1. Encrypt\n2. Decrypt\n3. Exit\n";
		cout << "Enter: ";
		cin >> v;
		
		if(v == 3)
		{
			break;
		}
		
		switch(v)
		{
			case 1: 
				data_encryption(path);
				break;
			case 2: 
				data_decryption(path_for_encrypted, path_for_keyfile);;
				break;
		}
	}
	
}

