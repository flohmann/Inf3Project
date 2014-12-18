#pragma once

#include"stdafx.h"
#include <vector>

#include"Node.h"
using namespace std;

Link::Link(Node& n, Node& s, Node& w, Node& e) : north(n), south(s), west(w), east(e)
{
	/*north = n;
	south = s;
	west = w;
	east = e;*/

	n.addLink(*this);
	s.addLink(*this);
	w.addLink(*this);
	e.addLink(*this);
}

Node& Link::getOppositeNeighbor(Node& n){
	if (north == n){
		return south;
	}
	if (south == n){
		return north;
	}
	if (east == n){
		return west;
	}
	//if (west == n){
	else {
		return east;
	}
}

Link::~Link()
{
}
