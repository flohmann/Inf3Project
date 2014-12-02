#include "Node.h"
#include <vector>;
#include "Link.h";



	Node::Node(int x, int y)
	{
		this->x = x;
		this->y = y;
	}

	int Node::getX(){
		return this->x;
	}
	int Node::getY(){
		return this->y;
	}

	int Node::getSize(){
		return linkList.size;
	}

	void Node::addLink(Link li){
		if (&li == nullptr){   // looking if the address(&) is null 
			printf("invalid link");
		}

		this->linkList.push_back(li);
	}

	std::vector<Link> Node::getLinks(){
		return linkList;
	}

	std::vector<Node> Node::getNeighborNode(){
		std::vector<Link> links;
		links = getLinks();
		if (!links.empty) {

			std::vector<Node> neighbor;	
			for (Link l : links){
				neighbor.push_back(l.getOppositeNeighbor(*this)); //pointer(*) on class itself
			}
			return neighbor;
		}
		return;
	}


	Node::~Node()
	{
		delete &linkList; //Address will deleted by destructor
	}



