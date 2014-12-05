#pragma once
#include "Node.h"

class DijkstraLink : public Link
{
public:
	DijkstraLink();
	DijkstraLink(Node north, Node south, Node west, Node east);
	DijkstraLink(Node north, Node south, Node west, Node east, int distance);
	DijkstraLink(Link);
	int getDistance();

	~DijkstraLink();

private:
	int distance = INT_MAX;
	void setDistance(int distance);
};

