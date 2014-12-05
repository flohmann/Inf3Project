#pragma once
#include <vector>
#include "Graph.h"

using namespace std;

class DijkstraGraph : public Graph
{
public:
	DijkstraGraph();
	void init();
	vector<DijkstraNode> getShortestPath(int xStart, int xEnd, int yStart, int yEnd);
	~DijkstraGraph();

};

