#pragma once
#include "Node.h";
#include <vector>;

// construktor/destructor, methodes and attributes of DijktraGraph
class Graph
{
public:
	Graph();
	void addNodes(Node n);
	bool hasNodes(Node n);
	int getAmount();
	std::vector<Node> getNodes();
	Node getNode(int x, int y);
	int getSize();
	void setNodes(std::vector<Node> list);
	~Graph();


private:
	std::vector<Node> nodeList;
	bool isNode = false;

};

