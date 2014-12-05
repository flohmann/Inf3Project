#include "Node.h"

// construktor/destructor, methodes and attributes of DijktraNode
class DijkstraNode : public Node
{
public:
	DijkstraNode();
	DijkstraNode(Node);
	DijkstraNode(int x, int y) : Node(x, y){
	}
	int getDistance();
	void setPrevious(DijkstraNode* previous);
	DijkstraNode getPrevious();
	~DijkstraNode();

private:
	int distance;
	DijkstraNode* previous = nullptr;
	void setDistance(int distance);
};
	