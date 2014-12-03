#include "stdafx.h"
#include "DijkstraLink.h"


DijkstraLink::DijkstraLink(Node north, Node south, Node west, Node east)
{
	base:(north, south, west, east);
}

DijkstraLink::DijkstraLink(Node north, Node south, Node west, Node east, int distance)
{
	this->north;
	this->south;
	this->west;
	this->east;
	setDistance(distance);
}

void DijkstraLink::setDistance(int distance){
	if (distance < 0) {
		printf("Distance must be > 0");
	}
	this->distance = distance;
}

int DijkstraLink::getDistance() {
	return distance;
}


DijkstraLink::~DijkstraLink()
{
}
