#pragma once

#include <vector>
#include "DijkstraGraph.h"
#include "DijkstraLink.h"

using namespace std;

DijkstraGraph::DijkstraGraph()
{
}
void DijkstraGraph::init()
{

	for (Node node : getNodes())
	{
		DijkstraNode dnode = (DijkstraNode)node;
		dnode.setPrevious(NULL);
		dnode.setDistance(INT_MAX); 
	}
}

std::vector<DijkstraNode> DijkstraGraph::getShortestPath(int xStart, int yStart, int xEnd, int yEnd)
{

	init();
	DijkstraNode start = (DijkstraNode)getNode(xStart, yStart);
	DijkstraNode end = (DijkstraNode)getNode(xEnd, yEnd);
	if ((&start == NULL) || (&end == NULL))
	{
		return;
	}
	if (start == end)
	{
		return;
	}

	start.setDistance(0);
	vector<DijkstraNode> list;
	for (Node n : getNodes())
	{
		list.push_back((DijkstraNode)n);
	}

	do
	{
		DijkstraNode *selected = NULL;
		for (DijkstraNode x : list)
		{
			if (&selected == NULL){ // check address to null
				selected = &x;
			}
			if (selected->getDistance() > x.getDistance())
			{
				vector<DijkstraNode> selectedNode;
				selected = &x;
				selectedNode.push_back(*selected);
				list.erase(selectedNode.begin, selectedNode.end);
			}
		}

		for (Link l : selected->getLinks())
		{
			DijkstraLink dlink = (DijkstraLink)l;
			DijkstraNode dnode = (DijkstraNode)l.getOppositeNeighbor(*selected);
			if (find(list.begin, list.end, selected)){
				if ((selected->getDistance() + dlink.getDistance() < dnode.getDistance()))
				{
					dnode.setDistance(selected->getDistance() + dlink.getDistance());
					dnode.setPrevious(selected);
				}
			}
		}
	} while (list.size>0);

	std::vector<DijkstraNode> ending;
	DijkstraNode x = end;
	do
	{
		ending.push_back(x);
		x = x.getPrevious();

	} while (&x != nullptr);

	return ending;
}


DijkstraGraph::~DijkstraGraph()
{
}
