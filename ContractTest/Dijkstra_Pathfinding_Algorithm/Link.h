#pragma once

//#include "Node.h"
using namespace std;
class Node;
class Link
{
	public:
		Node& north;
		Node& south;
		Node& west;
		Node& east;
		Link();
		Link(Node& north, Node& south, Node& west, Node& east);
		Node& getOppositeNeighbor(Node& nd);
		~Link();
		Link& operator=(const Link& element);

};
