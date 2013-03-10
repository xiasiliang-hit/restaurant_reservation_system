#pragma once

#include "Global.h"
#include "Protein.h"
#include "Phenotype.h"
#include "Test.h"

#define gpMax 2773 //bio_g->p 行数
//从original中抽取到index的数量
//INDEX_PHENOTYPES是morbidmap里面的表型数量决定的
//INDEX_GENES,和INDEX_PROTEINS是bioDBnet_results_geneID_EnsemblID.txt决定的
#define INDEX_PHENOTYPES 2817 //后验index里面的数量
#define INDEX_PROTEINS 14066  //...
#define INDEX_GENES 2773  //...

#define RELATE_PROTEINS 64 //基因最长关联59

#define iMax 5662 //morbidmap行数
//从bionet gene->protein 临时建立gene和protein映射
#define M 4096 //和global里面的一样
#define N 65535  //临时分配，结果是INDEX_PROTEINS
#define sMax 1897//2042 //selected.txt行数

//#define iMaxPhenotype = 5080
#define BIGLINE 169064 //Data\\original\\proteinMap.csv 行数

void CreateSelectFile();
void CreateIDFile();
void CreateProteinIDNew();
