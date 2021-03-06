// STL.cpp: 定義主控台應用程式的進入點。

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <vector>
#include <queue>
#include <stack>
#include <set>
#include <map>
#include <Algorithm>
using namespace std;

int main() {
	//VECTOR
	//Advantage:宣告時不用確定大小，可random access
	//Disadvangtage:內部刪除效率
	//Complexity:
	//      尾端:O(1)
	//      中間:O(n)
	cout << "--------VECTOR--------" << endl;
	vector<int> vec1;    // 宣告一個裝 int 的 vector

	vec1.push_back(10);
	vec1.push_back(20);  // 經過三次 push_back
	vec1.push_back(30);  // vec 是 [10, 20, 30]

	int length = vec1.size();        // length = 3
	for (int i = 0; i<length; i++) {
		cout << vec1[i] << endl;     
	}

	//print out all
	int arr[] = { 1, 2, 3, 4, 5 };
	vector<int> vec(arr, arr + 5);    // vec = [1, 2, 3, 4, 5]
	int len = vec.size();           // len = 5
	for (int i = 0; i<len; i++) {
		cout << vec[i] << endl;
	}
	// 把 0 放在 vec.begin() 的位置 -> [0, 1, 2, 3, 4, 5]
	vec.insert(vec.begin(), 0);
	// 在尾巴加三個 100 -> [0, 1, 2, 3, 4, 5, 100, 100, 100]
	vec.insert(vec.end(), 3, 100);
	// 移除第 0 個元素 -> [1, 2, 3, 4, 5, 100, 100, 100]
	vec.erase(vec.begin());
	// 移除最後一個元素 -> [1, 2, 3, 4, 5, 100, 100]
	vec.erase(vec.end() - 1);
	// 移除前五個元素 -> [100, 100]
	vec.erase(vec.begin(), vec.begin() + 5);
	cout << "SIZE:"<<vec.size() << endl;     // size = 2
	//若要全刪
	//vec.erase(vec.begin(), vec.end());
	cout << "Capacity for now:"<<vec.capacity() << endl;

	int arr2[] = { 3, 1, 4, 2, 5 };
	vector<int> vec2(arr2, arr2 + 5);    
	sort(vec2.begin(), vec2.begin() + 3);
	// 全部排序 -> [1, 2, 3, 4, 5]
	sort(vec2.begin(), vec2.end());
	// 反轉 -> [5, 4, 3, 2, 1]
	reverse(vec2.begin(), vec2.end());

	//Use iterator
	// 找 3 
	// 找不到就會回傳 vec.end()
	vector<int>::iterator it;
	it = find(vec.begin(), vec.end(), 3);
	if (it != vec.end()) {
		cout << "3 在裡面" << endl;
	}
	else {
		cout << "3 不在裡面" << endl;
	}


	// begin->1 end->5 
	vector<int>::iterator begin = vec.begin();
	vector<int>::iterator end = vec.end();
	vector<int>::iterator ite;
	for (ite = begin; ite != end; ite++) {
		cout << *ite << endl;
	}

	//2 Dimension array
	//vector<vector<int>> jvec(10); 10X10
	vector<int> array_2D[10]; //col = 10
	//分別開自己的row
	array_2D[0].push_back(00);
	array_2D[2].push_back(20);
	array_2D[2].push_back(21);
	array_2D[2].push_back(22);
	cout <<"動態陣列[0][0]:"<< array_2D[0][0]<<endl;
	cout << "動態陣列[2][2]:" << array_2D[2][2] << endl;
	//尋訪所有
	int iy=0;
	for (iy; iy < 10; ++iy) {
		vector<int>::iterator iter = array_2D[iy].begin();
		for (int ix = 0; iter != array_2D[iy].end(); ++iter, ++ix) {
			cout << *iter << endl;
		}
	}



	cout << "--------VECTOR--------" << endl;

	//QUEUE
	//Advantages:快速去除頭
	//Disadvantages:只能操作front、back
	cout << "--------QUEUE--------" << endl;
	queue<int> que;
	que.push(10);
	que.push(20);
	que.push(30);     // [10, 20, 30]

	cout << que.front() << endl;  // 10
	cout << que.back() << endl;   // 30
	
	que.pop();                    // 剩下[20, 30]
	cout << que.size() << endl;   // 2

	for (int i = 3; i<7; i++) {
		que.push(i * 10);
	}                   // [20, 30, 40, 50, 60]

	while (que.size() != 0) {
		cout << que.front() << endl;
		que.pop(); //接續印出
	}
	cout << "--------QUEUE--------" << endl;

	//STACK
	//Advantages:Easy use
	//Disadvantages:top好操作而已
	stack<int> s;
	cout << "--------STACK--------" << endl;
	s.push(10);     //  | 30 |
	s.push(20);     //  | 20 |   疊三個
	s.push(30);     //  |_10_|   10 在最下面

	for (int i = 0; i<s.size(); i++) {    // s.size() = 3
		cout << s.top() << endl;
		s.pop();
	}                                   // output 30, 20, 10
	cout << "--------STACK--------" << endl;

	//SET
	//Advantages:檢查元素有無容易
	//Disadvantages:速度慢
	set<int> Set;
	cout << "--------SET--------" << endl;
	Set.insert(20);   // {20}
	Set.insert(10);   // {10, 20}
	Set.insert(30);   // {10, 20, 30}

	cout << Set.count(20) << endl;    // 存在 -> 1
	cout << Set.count(100) << endl;   // 不存在 -> 0

	Set.erase(20);                    // {10, 30}
	cout << Set.count(20) << endl;    // 0
	cout << "--------SET--------" << endl;
	
	//MAP
	//Advantages:mapping值容易設定
	//Disadvantages:對應越多越慢
	cout << "--------MAP--------" << endl;
	map<string, int> m;     // 從 string 對應到 int

							// 設定對應的值
	m["one"] = 1;       // "one" -> 1
	m["two"] = 2;       // "two" -> 2
	m["three"] = 3;     // "three" -> 3

	cout << m.count("two") << endl;     // 1 -> 有對應
	cout << m.count("ten") << endl;     // 0 -> 沒有對應


	cout << m["one"] << endl;       // 1
	cout << m["three"] << endl;     // 3
	cout << m["ten"] << endl;       // 0 (無對應值)

	cout << "--------MAP--------" << endl;

	system("pause");
	return 0;
}
