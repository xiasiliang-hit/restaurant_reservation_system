//create selectedFile, proteinIDFile, phenotypeIDFile
#include "PreProcess.h"


static const char* morbidMapFile = "Data\\revised\\morbidmap_revised";
static const char* geneProteinFile = "Data\\original\\bioDBnet_results_geneID_EnsemblID.txt";

static const char* pchGeneIndexFile = "Data\\mid\\geneIndex.txt";
static const char* pchProteinIndexFile = "Data\\mid\\proteinIndex.txt";
static const char* pchPhenotypeIndexFile = "Data\\mid\\phenotypeIndex.txt";

static const char* NOSIMIINFO = "609033";



//static const int iMax = 5662; //morbidmap行数

static Protein selectProteins[INDEX_PROTEINS];
static Phenotype selectPhenotypes[INDEX_PHENOTYPES];
static int selectPhenotypeProtein[INDEX_PHENOTYPES][CAUSE_PROTEINS];

static Gene selectGenes[INDEX_GENES];
static int GeneProtein[INDEX_GENES][RELATE_PROTEINS];
static ProteinMap proteinMaps[INDEX_PROTEINS];



static Phenotype genes[M];

static Protein proteins[N];
//static const int gpMax = 2773; //bio_g->p 行数
void CreateIndexGeneProtein()
{
	MsgFunction("CreateIndexGeneProtein");

	char proteinTemp[LINE_LENGTH] = {'\0'};

	char gene[PHENOTYPE_LENGTH] = {'\0'};
	//char protein[PROTEIN_LENGTH] = {'\0'};

	int m = 0;
	int n = 0;

	MsgRead(geneProteinFile);
	FILE* fin = fopen(geneProteinFile, "r");
	if (fin)
	{
		int i = 0;
		for(i = 0; !feof(fin) && i <= gpMax - 1; i++)
		{
			fscanf(fin, "%s %s", gene, proteinTemp);
//debug
//if (strcmp(gene, "609062") == 0)
//{
//	cout<< gene;
//}
			strcpy(genes[m].chName, gene);
			m++;

			char* pProteinNameHead = proteinTemp;
			int current = 0;
			for (current = 0; current <= strlen(proteinTemp) - 1 ; current += PROTEIN_LENGTH)
			{
				pProteinNameHead = proteinTemp + current;
				strncpy(proteins[n].chName, pProteinNameHead, PROTEIN_LENGTH - 1);
				n++;
			}

		}
		fclose(fin);
	}
	else
	{
		MsgError(selectedFile);
	}

	qsort (genes, m, sizeof(Gene), GeneCompare);
	qsort (proteins, n, sizeof(Protein), ProteinCompare);

	MsgWrite(pchGeneIndexFile);
	FILE* fout = fopen(pchGeneIndexFile, "w");
	if (fout)
	{
		int j = 0;
		for (j = 0; j <= m - 1; j++)
		{
			fprintf(fout, "%s %d\n", genes[j].chName, j);
		}
		printf("->INDEX_GENES:%d\n", j);
		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(pchPhenotypeIDFile);
	}


	MsgWrite(pchProteinIDFile);
	fout = fopen(pchProteinIndexFile, "w");
	if (fout)
	{
		char last [PROTEIN_LENGTH] = {'\0'};
		int k = 0;
		int j = 0;
		for (j = 0; j <= n - 1; j++)
		{
			if (strcmp(proteins[j].chName, last) != 0)
			{
				fprintf(fout, "%s %d\n", proteins[j].chName, k);
				k++;
			}
			else
			{}
			strcpy(last, proteins[j].chName);
		}
		printf("->INDEX_PROTEINS:%d", k);
		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(pchProteinIDFile);
	}
}

void CreateIndexPhenotype()
{
	MsgFunction("CreateIndexPhenotype");

	int i = 0;
	//Phenotype tempPhenotype;
	Phenotype phenotypes[iMax];//从morbidmap->index

	MsgRead(morbidMapFile);
	FILE* fin = fopen(morbidMapFile, "r");
	if (fin)
	{
		int j = 0;
		for(j = 0; j <= iMax -1 && !feof(fin); j++)
		{
			char aLine[LINE_LENGTH] = {'\0'};
			fgets(aLine, LINE_LENGTH, fin);
			*(aLine+strlen(aLine)-1) = '\0';

			char* posP = aLine;
			char* p = ExtractPhenotypeID(aLine);

			while (p != NULL)
			{
				strcpy(phenotypes[i].chName, p);
				i++;

				posP = strstr(aLine, p);
				posP = posP + PHENOTYPE_LENGTH - 1;
				if (posP <= aLine + strlen(aLine) )
				{
					p = ExtractPhenotypeID(posP);
				}
				else
				{
					p = NULL;
				}
			}
		}
		qsort(phenotypes, i, sizeof(Phenotype), PhenotypeCompare);
	}
	else
	{}

	FILE* fout = fopen(pchPhenotypeIndexFile, "w");
	if (fout)
	{
		//string last = "";
		char last[PHENOTYPE_LENGTH] = {'\0'};
		int k = 0;
		int j = 0;
		for (j = 0; j <= i - 1; j++)
		{
			if (strcmp(phenotypes[j].chName, last) != 0)
			{
				//fout << phenotypes[j].chName << " " << k << endl;
				fprintf(fout, "%s %d\n",phenotypes[j].chName, k);
				k++;
			}
			else
			{}
			strcpy(last, phenotypes[j].chName);
		}
		printf("->INDEX_PHENOTYPES:%d\n", k);
		fflush(fout);
		fclose(fout);
	}
	else
	{}
}

void IndexInitial()
{
	MsgFunction("IndexInitial");
	FILE* pFile = NULL;

	MsgRead(pchProteinIndexFile);
	if (pFile = fopen(pchProteinIndexFile, "r"))
	{
		int step_i = 0;
		for (step_i = 0; step_i <= INDEX_PROTEINS - 1; ++step_i)
		{
			fscanf(pFile, "%s %d", selectProteins[step_i].chName,
				&(selectProteins[step_i].iID));
		}
		fclose(pFile);
	}
	else
	{
		MsgError(pchProteinIndexFile);
	}

	MsgRead(pchPhenotypeIndexFile);
	if (pFile = fopen(pchPhenotypeIndexFile, "r"))
	{
		int step_i = 0;
		for (step_i = 0; step_i <= INDEX_PHENOTYPES - 1; ++step_i)
		{
			fscanf(pFile, "%s %d", selectPhenotypes[step_i].chName,
				&(selectPhenotypes[step_i].iID));
		}
		fclose(pFile);
	}
	else
	{
		MsgError(pchPhenotypeIndexFile);
	}

	MsgRead(pchGeneIndexFile);
	if (pFile = fopen(pchGeneIndexFile, "r"))
	{
		int step_i = 0;
		for (step_i = 0; step_i <= INDEX_GENES - 1; ++step_i)
		{
			fscanf(pFile, "%s %d", selectGenes[step_i].chName,
				&(selectGenes[step_i].iID));
//debug
//if(strcmp(selectGenes[step_i].chName, "613733")==0)
//{
//	cout << "";
//}
		}
		fclose(pFile);
	}
	else
	{
		MsgError(pchGeneIndexFile);
	}
}

void ReadGeneProtein()
{
	MsgFunction("ReadGeneProtein");

	IndexInitial();

	char gene[PHENOTYPE_LENGTH] = {'\0'};
	char protein[PROTEIN_LENGTH] = {'\0'};
	char proteinTemp[LINE_LENGTH] = {'\0'};

	MsgRead(geneProteinFile);
	FILE* pFile = fopen(geneProteinFile, "r");
	if (pFile)
	{
		while (!feof(pFile))
		{
			fscanf(pFile, "%s %s", gene, proteinTemp);//可以跳过空行

			Phenotype tempGene;
			strcpy(tempGene.chName, gene);
//debug
//if (strcmp(gene, "613733") == 0)
//{
//cout << gene;
//}
			Gene* pResult = NULL;
			pResult = (Gene*) bsearch(&tempGene, selectGenes, INDEX_GENES, sizeof(Gene), GeneCompare);
			if (pResult != NULL)
			{
				int genePos =  pResult - selectGenes;

				int i = 0;
				char* pProteinNameHead = proteinTemp;

				int current = 0;
				for (current = 0; current <= strlen(proteinTemp) - 1 ; current += PROTEIN_LENGTH)
				{
					pProteinNameHead = proteinTemp + current;
					strncpy(protein, pProteinNameHead, PROTEIN_LENGTH - 1);
					protein[PROTEIN_LENGTH - 1] = '\0';

					Protein tempProtein;
					strcpy(tempProtein.chName, protein);
					Protein* pResult = NULL;
					pResult = (Protein*) bsearch(&tempProtein, selectProteins, INDEX_PROTEINS, sizeof(Protein), ProteinCompare);

					if (pResult != NULL)
					{
						int proteinPos =  pResult - selectProteins;

						GeneProtein[genePos][i] = proteinPos;
						i++;

					}
					else
					{
						MsgError("error: protein index:");
						MsgError(tempProtein.chName);
					}
				}
				GeneProtein[genePos][i] = CAUSE_PROTEIN_END;
			}
			else
			{
				MsgError("error gene index");
				MsgError(tempGene.chName);
			}
		}
		fclose(pFile);
	}
	else
	{
		MsgError(geneProteinFile);
	}

//test
	//ofstream fout("Data\\test\\selectedGeneProtein.test", ios::out);
	//for (i = 0; i <= INDEX_GENES -1 ; i++)
	//{
	//	for (j = 0; j <= CAUSE_PROTEINS - 1; j++)
	//	{
	//		fout << GeneProtein[i][j] << ",";
	//		if (GeneProtein[i][j] == CAUSE_PROTEIN_END)
	//		{
	//			break;
	//		}
	//	}
	//	fout<<endl;
	//}
	//fout.flush();
	//fout.close();
}

static char* pchIndexFile = "Data\\revised\\PhenotypeSimilarityMatrixIndex.txt";
//static const int iMaxPhenotype = 5080;
Phenotype phenotypeSimiIndex[iMaxPhenotype];
void ReadPhenotypeSimiIndex()
{
	MsgRead(pchIndexFile);

	FILE* fin = fopen(pchIndexFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; i <= iMaxPhenotype - 1; i++)
		{
			char aLine[PHENOTYPE_LENGTH] = {'\0'};
			fscanf(fin, "%s", aLine);

			strcpy(phenotypeSimiIndex[i].chName, aLine);
			phenotypeSimiIndex[i].iID = i;
		}
		fclose(fin);
	}
	else
	{}
}


void CreateSelectFile()
{
	MsgFunction("CreateSelectFile");

	CreateIndexGeneProtein();
	CreateIndexPhenotype();
	ReadGeneProtein();
	memset(selectPhenotypeProtein, CAUSE_PROTEIN_END, sizeof(selectPhenotypeProtein));

	//Phenotype tempPhenotype;

	MsgRead(morbidMapFile);
	FILE* fin = fopen(morbidMapFile, "r");
	if (fin)
	{
		int w = 0;
		for(w = 0; w <= iMax -1 && !feof(fin); w++)
		{
			char aLine[LINE_LENGTH] = {'\0'};
			fgets(aLine, LINE_LENGTH, fin);
			*(aLine+strlen(aLine)-1) = '\0';

			char* posP = aLine;
			char* posG  = aLine;
			char* p = ExtractPhenotypeID(aLine);
			char* g = ExtractGeneID(aLine);

			while (p != NULL)
			{
				Phenotype tempPhenotype;

				strcpy(tempPhenotype.chName, p);

				Phenotype* pPh = NULL;
				pPh = (Phenotype*) bsearch(&tempPhenotype, selectPhenotypes, INDEX_PHENOTYPES, sizeof(Phenotype), PhenotypeCompare);
				if (pPh != NULL)
				{
					int phenotypePos = pPh -> iID;
					while(g != NULL) //in fact 一行一个G
					{
						Phenotype tempGene;
						strcpy(tempGene.chName, g);
						Gene* pG = NULL;
						pG = (Gene*) bsearch(&tempGene, selectGenes, INDEX_GENES, sizeof(Gene), GeneCompare);
						if (pG != NULL)
						{
							int genePos = pG -> iID;
							int end = 0;
							int k = 0;
							for (k = 0;k <= CAUSE_PROTEINS - 1 ; k++ )// j <= RELATE_PROTEINS - 1
							{
								if (selectPhenotypeProtein[phenotypePos][k]== CAUSE_PROTEIN_END)
								{
									end = k;
									break;
								}
								else
								{}
							}

							int m = 0;
							for (m = 0; m <= RELATE_PROTEINS - 1 && GeneProtein[genePos][m] != CAUSE_PROTEIN_END; m++ )
							{
								bool isExist = false;
								int n = 0;
								for (n = 0; n <= RELATE_PROTEINS - 1 && selectPhenotypeProtein[phenotypePos][n] != CAUSE_PROTEIN_END ; n++)
								{
									if (selectPhenotypeProtein[phenotypePos][n] == GeneProtein[genePos][m])
									{
										isExist = true;
										break;
									}
									else
									{}
								}

								if (isExist == false)
								{
									selectPhenotypeProtein[phenotypePos][end] = GeneProtein[genePos][m];
									end++;
								}
								else
								{}
							}
							selectPhenotypeProtein[phenotypePos][end] = CAUSE_PROTEIN_END;
						}
						else
						{}
						//strcpy(phenotypes[i].chName, rs[j].str().substr(1,6).c_str());
						//i++ ;

						posG = strstr(aLine, g);
						posG = posG + GENE_LENGTH - 1;
						if (posG <= aLine + strlen(aLine) )
						{
							g = ExtractPhenotypeID(posG);
						}
						else
						{}

					}
				}
				else
				{}

				posP = strstr(aLine, p);
				posP = posP + PHENOTYPE_LENGTH - 1;
				if (posP <= aLine + strlen(aLine) )
				{
					p = ExtractPhenotypeID(posP);
				}
			}
		}
		fclose(fin);
	}
	else
	{}

//test
	/*ofstream fout1("Data\\test\\selected.test", ios::out);

	for (i = 0; i <= TOTAL_PHENOTYPES -1 ; i++)
	{
		if (selectPhenotypeProtein[i][0] == CAUSE_PROTEIN_END)
		{
			continue;
		}
		else
		{}

		if (strcmp(selectPhenotypes[i].chName, NOSIMIINFO) == 0)
		{
			break;
		}
		else
		{}

		bool isHG = false;
		for (k = 0; k <= CAUSE_PROTEINS - 1 && selectPhenotypeProtein[i][k] != CAUSE_PROTEIN_END; k++)
		{
			string proteinLoc = proteinMaps[selectPhenotypeProtein[i][k]].pos.oriString;
			if (proteinLoc.find('H') != string::npos  || proteinLoc.find('G') != string::npos)
			{
				isHG = true;
				break;
			}
			else
			{}
		}

		if (isHG == false)
		{
			for (j = 0; j <= CAUSE_PROTEINS - 1; j++)
			{

				fout1 << selectPhenotypeProtein[i][j] << ",";
				if (selectPhenotypeProtein[i][j] == CAUSE_PROTEIN_END)
				{
					break;
				}
				else
				{}
			}
			fout1<<endl;
		}
		else
		{}
	}
	fout1.flush();
	fout1.close();*/

	//609033以下的，没有表型相似度了，break
	//去掉没有蛋白质的
	//去掉蛋白质区间是H,G表示的
	//output selected.txt
	ReadProteinMap(proteinMaps, selectProteins, INDEX_PROTEINS);
	ReadPhenotypeSimiIndex();

	MsgWrite(selectedFile);
	FILE* fout = fopen(selectedFile, "w");

	if (fout)
	{
		int available = 0;
		int i = 0;
		for (i = 0; i <= INDEX_PHENOTYPES -1; i++)
		{
		    Phenotype tempPhenotype = selectPhenotypes[i];

			Phenotype* pPh = NULL;
			pPh = (Phenotype*) bsearch(&tempPhenotype, phenotypeSimiIndex, iMaxPhenotype, sizeof(Phenotype), PhenotypeCompare);
			if (pPh == NULL)
			{
				continue;
			}
			else
			{}


			//去掉没有找到蛋白质的
			if (strcmp(selectPhenotypes[i].chName, NOSIMIINFO) == 0)
			{
				break;
			}
			else
			{}

			//以下没有表型相似度
			if (selectPhenotypeProtein[i][0] == CAUSE_PROTEIN_END)
			{
				continue;
			}
			else
			{}

			//去掉没有区间信息的(蛋白质区间没有，或者编码以H,G开头的)
			bool isHG = false;
			int k = 0;
			for (k = 0; k <= CAUSE_PROTEINS - 1 && selectPhenotypeProtein[i][k] != CAUSE_PROTEIN_END; k++)
			{
	//debug
	//cout << proteinMaps[selectPhenotypeProtein[i][k]].chName << endl;
	//cout << i <<endl;

				//string proteinPosStr = proteinMaps[selectPhenotypeProtein[i][k]].oriString;
				//if (proteinPosStr.at(0) == 'G' || proteinPosStr.at(0) == 'H')
				int proteinLoc = proteinMaps[selectPhenotypeProtein[i][k]].pos;
				if (proteinLoc == UNNORMAL_POS)
				{
					isHG = true;
					break;
				}
				else
				{}
			}
			if (isHG == false)
			{
				available++;
				//fout << selectPhenotypes[i].chName << " ";
				fprintf(fout, "%s ", selectPhenotypes[i].chName);
				int j = 0;
				for (j = 0; j <= CAUSE_PROTEINS - 1 && selectPhenotypeProtein[i][j] != CAUSE_PROTEIN_END; j++)
				{

					//fout << selectProteins[selectPhenotypeProtein[i][j]].chName << ",";
					fprintf(fout, "%s,", selectProteins[selectPhenotypeProtein[i][j]].chName);
					//fout << selectPhenotypeProtein[i][j] << ",";

				}
				//fout << endl;
				fprintf(fout, "\n");
			}
			else //含有'H','G'开头的不规则蛋白质区间编码，表型不要了
			{}
		}
		printf("->sMax:%d\n", available);

		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(selectedFile);
	}
}

//读selected，建立phenotype索引和protein索引
static Phenotype phenotypesOut[M];
static Protein proteinsOut[N];

//static const int sMax = 1897;//2042; //selected.txt行数
void CreateIDFile()
{
	MsgFunction("CreateIDFile");

	//char aLine[LINE_LENGTH] = {'\0'};
	char proteinTemp[LINE_LENGTH] = "";
	char phenotype[PHENOTYPE_LENGTH] = "";
	char protein[PROTEIN_LENGTH] = "";

	int m = 0;
	int n = 0;

	MsgRead(selectedFile);
	FILE* fin = fopen(selectedFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; !feof(fin) && i <= sMax-1; i++)
		{
			fscanf(fin, "%s %s", phenotype, proteinTemp);
//debug
/*if (strcmp(phenotype, "202400") == 0)
{
	cout<< aLine;
}*/
			if (strcmp(phenotype, "") != 0)
			{
				strcpy(phenotypesOut[m].chName, phenotype);
				m++;

				char* pProteinNameHead = proteinTemp;
				int current = 0;
				for (current = 0; current <= strlen(proteinTemp) - 1 ; current += PROTEIN_LENGTH)
				{
					pProteinNameHead = proteinTemp + current;
					strncpy(proteinsOut[n].chName, pProteinNameHead, PROTEIN_LENGTH - 1);
					n++;
				}
			}
			else
			{}
		}
		fclose(fin);
	}
	else
	{
		MsgError(selectedFile);
	}

	qsort(phenotypesOut, m, sizeof(Phenotype), PhenotypeCompare);
	qsort(proteinsOut, n, sizeof(Protein), ProteinCompare);

	MsgWrite(pchPhenotypeIDFile);
	FILE* fout = fopen(pchPhenotypeIDFile, "w");
	if (fout)
	{
		//string last = "";
		int j = 0;
		for (j = 0; j <= m - 1; j++)
		{
			fprintf(fout, "%s %d\n", phenotypesOut[j].chName, j);
		}
		printf("->TOTAL_PHENOTYPES:%d\n", j);
		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(pchPhenotypeIDFile);
	}


	/*MsgWrite(pchProteinIDFile);
	fout = fopen(pchProteinIDFile, "w");
	if (fout)
	{
		char last[PROTEIN_LENGTH] = {'\0'};

		int k = 0;
		int j = 0;
		for (j = 0; j <= n - 1; j++)
		{
			if (strcmp(proteinsOut[j].chName, last) != 0)
			{
				fprintf(fout, "%s %d\n", proteinsOut[j].chName, k);
				k++;
			}
			else
			{}
			strcpy(last, proteinsOut[j].chName);
		}
		printf("->TOTAL_PROTEINS:%d\n", k);
		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(pchProteinIDFile);
	}*/
	CreateProteinIDNew();
}

//static const int BIGLINE = 169064;
const char* proteinMapFile = "Data\\original\\proteinMap.csv";
static Protein pTempArray[BIGLINE];
void CreateProteinIDNew()
{
	MsgFunction("CreateProteinIDNew");

	//Protein tempProtein;

	MsgRead(proteinMapFile);
	FILE* fin = fopen(proteinMapFile, "r");

	if (fin)
	{
		int i = 0;
		int pos = 0;
		for (i = 0; i <= BIGLINE - 1 && !feof(fin); i++ )
		{
			char aLine[LINE_LENGTH];
			fgets(aLine, LINE_LENGTH, fin);

			char* del = ",";
			char* LF = "\n";

			char* name = strtok(aLine, del);
			char* chromosome = strtok(NULL, del);
			char* band = strtok(NULL, LF);

			if (!name || !chromosome || !band)
			{
				continue;
			}

			else if (chromosome[0] == 'G' ||chromosome[0] == 'H')
			{
				continue;
			}
			else if (i == 0)
			{
				continue;
			}
			else
			{
				//pTempArray[pos].iID = pos;
				strcpy(pTempArray[pos].chName, name);
				pos++;
			}
		}
		printf("->TOTAL_PROTEINS:%d\n", pos);
		qsort(pTempArray, pos, sizeof(Protein), ProteinCompare);

		FILE* fout = fopen(pchProteinIDFile, "w");
        MsgWrite(pchProteinIDFile);
		if (fout)
		{
		    int i = 0;
			for (i = 0; i<=pos-1;i++)
			{
				fprintf(fout, "%s %d\n",  pTempArray[i].chName, i);
			}
		}
		else
		{
			MsgError(pchProteinIDFile);
		}


		fclose(fin);
		fclose(fout);
	}
	else
	{
		MsgError(proteinMapFile);
	}
}

