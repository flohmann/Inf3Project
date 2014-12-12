#pragma once
#include "DijkstraNode.h"
#include "Node.h"
using namespace std;

DijkstraNode::DijkstraNode(int x, int y) : Node(x, y)
{
}

void DijkstraNode::setDistance(int distance){
	if (distance < 0)
	{
		printf("invalid distance"); 
	}
	this->distance = distance;
}

int DijkstraNode::getDistance(){
	return distance;
}

void DijkstraNode::setPrevious(DijkstraNode* previous){
	this->previous = previous;
}

DijkstraNode DijkstraNode::getPrevious(){
	return *previous;

}
DijkstraNode::~DijkstraNode()
{
}


