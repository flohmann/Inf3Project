#pragma once


class DijkstrasRosetta
{
	DijkstrasRosetta();
	
	typedef int vertex_t;
	typedef double weight_t;
	typedef int vertex_x;
	typedef int vertex_y;
	const weight_t max_weight = std::numeric_limits<double>::infinity();
	

	struct neighbor{
		
		vertex_t target;
		weight_t weight;
		vertex_x x;
		vertex_y y;
		neighbor(vertex_t arg_target, weight_t arg_weight, vertex_x arg_x, vertex_y arg_y);
			
	}
	
	void DijkstraComputePaths(vertex_t source, const adjacency_list_t &adjacency_list, std::vector<weight_t> &min_distance,
		std::vector<vertex_t> &previous);
	typedef std::vector <std::vector<neighbor> >;
	std::list<vertex_t> DijkstraGetShortestPathTo(vertex_t vertex, const std::vector<vertex_t> &previous);
	~DijkstrasRosetta();
};