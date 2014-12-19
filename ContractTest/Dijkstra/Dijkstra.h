#pragma once
#include "stdafx.h"

typedef int vertex_t;
typedef double weight_t;


std::list<vertex_t> DijkstraGetShortestPathTo(
	vertex_t vertex, const std::vector<vertex_t> &previous);

struct neighbor {
	vertex_t target;
	weight_t weight;
	neighbor(vertex_t arg_target, weight_t arg_weight)
		: target(arg_target), weight(arg_weight) { }
};

typedef std::vector<std::vector<neighbor> > adjacency_list_t;


void DijkstraComputePaths(vertex_t source,
	const adjacency_list_t &adjacency_list,
	std::vector<weight_t> &min_distance,
	std::vector<vertex_t> &previous);

extern "C"
{
	__declspec(dllexport) int* findPath(int from, int to, int* map, int mapw, int maph, int &pathlength);
	__declspec(dllexport) void release_Array(int* pArray);
}
