#pragma once
#include <vector>
#include "Node.h"

using namespace std;

// construktor/destructor, methodes and attributes of DijktraGraph
class Graph
{
public:
	Graph();
	void addNodes(Node n);
	bool hasNodes(Node n);
	int getAmount();
	vector<Node> getNodes();
	Node getNode(int x, int y);
	int getSize();
	void setNodes(std::vector<Node> list);
	~Graph();


private:
	vector<Node> nodeList;
	bool isNode = false;

};

