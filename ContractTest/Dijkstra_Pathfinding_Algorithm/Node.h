#pragma once
#include <vector>;
#include "Link.h";
#include "DijkstraNode.h";

class Node
{
public:
	Node();
	Node(int x, int y);
	Node(DijkstraNode);
	bool operator == (const Node& n);
	int getX();
	int getY();
	int getSize();
	void addLink(Link li);
	std::vector<Link> getLinks();
	std::vector<Node> getNeighborNode();
	~Node();

private:
	int x;
	int y;
	std::vector<Link> linkList;
};

