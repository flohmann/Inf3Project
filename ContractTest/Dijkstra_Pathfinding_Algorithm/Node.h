#include "DijkstraNode.h"
#include <vector>

#include <stdio.h>
using namespace std;



class Link;
class Node
{
public:


	Node();
	Node(int x, int y);
	bool operator == (const Node& n);
	int getX();
	int getY();
	int getSize();
	void addLink(Link li);
	vector<Link>  getLinks();
	vector<Node>  getNeighborNode();
	~Node();

private:
	int x;
	int y;
	vector<Link>  linkList;
};

