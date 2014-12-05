#pragma once
#include "Node.h"


class DijkstraNode : public Node
{
public:
	DijkstraNode();
	DijkstraNode(Node n);
	DijkstraNode(int x, int y);
	void setDistance(int distance);
	int getDistance();
	void setPrevious(DijkstraNode* previous);
	DijkstraNode getPrevious();
	~DijkstraNode();

private:
	int distance;
	DijkstraNode* previous = nullptr;
};
	