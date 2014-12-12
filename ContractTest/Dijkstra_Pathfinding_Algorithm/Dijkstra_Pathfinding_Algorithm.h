#pragma once
using namespace std;
//Declaring DLL Interface
extern "C"
{
	__declspec(dllexport) int* findPath(int from, int to, int* map, int mapw, int maph, int pathlength);
}