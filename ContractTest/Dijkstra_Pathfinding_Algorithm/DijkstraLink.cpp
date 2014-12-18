#pragma once
#include "stdafx.h"
#include "DijkstraLink.h"
using namespace std;
//Constructors
DijkstraLink::DijkstraLink(Node north, Node south, Node west, Node east): Link(north, south, west, east)
{

}

DijkstraLink::DijkstraLink(Node north, Node south, Node west, Node east, int distance)
{
	this->north;
	this->south;
	this->west;
	this->east;
	setDistance(distance);
}

//Setter and Getter
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
