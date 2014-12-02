#pragma once
#include "Node.h";

class Link
{
public:
	Node north;
	Node south;
	Node west;
	Node east;
	Link();
	Link(Node north, Node south, Node west, Node east);
	Node getOppositeNeighbor(Node nd);
	~Link();

};
