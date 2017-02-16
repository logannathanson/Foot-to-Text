#include <string>
#include <fstream>
#include <vector>
#include <iostream>

using namespace std;

void pretty_print(vector<vector<string>> &vec, int cat, int phrase, bool in_category){
	cout << endl;
	for (int i = 0; i < vec.size(); ++i){
		for (int j = 0; j < vec[i].size(); ++j){
			if ((j == 0 && i == cat && !in_category) || (i == cat && j == phrase && in_category)){
				cout << "> ";
			}
			cout << vec[i][j] << endl;
		}
	}
	cout << endl;
}

void pretty_print2(vector<vector<string>> &vec, int cat, int phrase, bool in_category){
	cout << endl;
	if (!in_category){
		if (cat + 4 < vec.size()){
			cout << "> ";
			for (int i = cat; i < cat + 4; ++i){
				cout << vec[i][0] << endl;
			}
		}
		else{
			for (int i = vec.size() - 4; i < vec.size(); ++i){
				if (i == cat){
					cout << "> ";
				}
				cout << vec[i][0] << endl;
			}
		}
	}
	else{
		if (phrase + 4 < vec[cat].size()){
			cout << "> ";
			for (int i = phrase; i < phrase + 4; ++i){
				cout << vec[cat][i] << endl;
			}
		}
		else{
			for (int i = vec[cat].size() - 4; i < vec[cat].size(); ++i){
				if (i == phrase){
					cout << "> ";
				}
				cout << vec[cat][i] << endl;
			}
		}
	}

	cout << endl;
}

int main(){
	string filename = "phrases.txt";
	ifstream ifs(filename);

	string line = "";

	vector<vector<string>> phrases;

	int cat = -1;

	while (getline(ifs, line)){
		//cout << line << endl;
		if (line[0] != '\t'){
			++cat;
			phrases.push_back(vector<string>());
			phrases[cat].push_back(line);
		}
		else{
			//remove initial tab character
			phrases[cat].push_back(line.erase(0, 1));
		}
	}


	int input = 0;
	int c = 0;
	int category = 0;
	int phrase = 1;
	bool in_category = false;
	pretty_print2(phrases, category, phrase, in_category);

	while (true){
		cin >> input;
		switch (input){
			case 1:
				cout << "back" << endl;
				in_category = 0;
				phrase = 1;
				break;
			case 2:
				cout << "down" << endl;
				if (!in_category){
					if (category + 1 < phrases.size()){
						++category;
					}
				}
				else{
					if (phrase + 1 < phrases[category].size()){
						++phrase;
					}
				}
				break;
			case 3:
				cout << "up" << endl;
				if (!in_category){
					if (category - 1 >= 0){
						--category;
					}
				}
				else{
					if (phrase - 1 >= 1){
						--phrase;
					}
				}
				break;
			case 4:
				cout << "select" << endl;
				if (!in_category){
					in_category = true;
					phrase = 1;
				}
				
				else{
					cout << "PRINTING PHRASE: " << phrases[category][phrase] << endl << endl;
				}
				break;
		}
		pretty_print2(phrases, category, phrase, in_category);
	}

	return 0;
}