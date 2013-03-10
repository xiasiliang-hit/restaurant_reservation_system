#include "Protein.h"

static const char* proteinSimilarityFile = "Data\\revised\\protein.links.v9.0.005_normalized.txt";
static const char* proteinSimilarityIndex = "Data\\protein.links.index.bin"; //索引文件
static const char* proteinMapFile = "Data\\original\\proteinMap.csv";
const int iMax = 169094;  //lines of proteinMap

void CreateProteinSimilarityFile()
{
	//proteinSimilarity = (ProteinSimilarityItem*)malloc(sizeof(ProteinSimilarityItem)*TOTAL_SIMILARITY);


	MsgFunction("CreateProteinSimilarityFile");

	MsgRead(proteinSimilarityFile);
	FILE* pFile = fopen(proteinSimilarityFile, "r");
	FILE* indexFile;

	//initialize proteinSimiIndexs array
	int i = 0;
	for (i = 0;i < TOTAL_PROTEINS; ++i)
	{
		proteinSimiIndexs[i] = -1;
	}

	if (pFile)
	{
		char chBuffer[100] = {0};
		int i = 0;
		int prepProteinID = -1;
		ProteinSimilarityItem temp;

		while (!feof(pFile) && i < TOTAL_PROTEIN_SIMILARITY)
		{
			memset(chBuffer, 0, sizeof(chBuffer));
			fscanf(pFile, "%s", chBuffer);
			if (strlen(chBuffer) > 0)
			{
				char chProtein[PROTEIN_LENGTH];
				chProtein[PROTEIN_LENGTH - 1] = 0;
				memcpy(chProtein, chBuffer, sizeof(char) * (PROTEIN_LENGTH - 1));
				int iProteinA = ProteinNameToID(chProtein);
				memcpy(chProtein, chBuffer + PROTEIN_LENGTH, sizeof(char) * (PROTEIN_LENGTH - 1));
				int iProteinB = ProteinNameToID(chProtein);

				if (iProteinA >= 0 && iProteinB >= 0)
				{
					//proteinSimilarity[iProteinA][iProteinB] = atof(chBuffer + PROTEIN_LENGTH * 2);
					float simi = atof(chBuffer + PROTEIN_LENGTH * 2);
					temp.proteinAID = iProteinA;
					temp.proteinBID = iProteinB;
					temp.similarity = simi;
					proteinSimilarity[i] = temp;

					if (iProteinA != prepProteinID)
					{
						prepProteinID = iProteinA;
						proteinSimiIndexs[iProteinA] = i;
					}
					else
					{
					}
					++i;
				}
				else
				{
				}
			}
			else
			{
				break;
			}
		}


		printf("->TOTAL_SIMILARITY:%d\n", i);
		fclose(pFile);
	}
	else
	{
		printf("%s open error\n", proteinSimilarityFile);
	}

	MsgWrite(proteinSimilarityFileBin);
	MsgWrite(proteinSimilarityIndex);
	if ((pFile = fopen(proteinSimilarityFileBin, "wb")) && (indexFile = fopen(proteinSimilarityIndex, "wb")))
	{
		fwrite(proteinSimilarity, sizeof(ProteinSimilarityItem), TOTAL_PROTEIN_SIMILARITY, pFile);
		fwrite(proteinSimiIndexs, sizeof(int),TOTAL_PROTEINS,indexFile);

		fflush(pFile);
		fflush(indexFile);

		fclose(pFile);
		fclose(indexFile);
	}
	else
	{
		printf("%s open error\n", proteinSimilarityFileBin);
	}
}
int ProteinCompare(const void* pA, const void* pB)
{
	return strcmp ((*(Protein*)pA).chName , (*(Protein*)pB).chName);
}

void ReadProteinMap(ProteinMap* pProteinMaps, Protein* pProtein, int pSize)
{
	MsgFunction("ReadProteinMap");

//	int i = 0;
//	for (i = 0; i <= TOTAL_PROTEINS - 1; i++)
//	{
//		strcpy((pProteinMaps+i)->chName, "");
//	}

	Protein tempProtein;

	MsgRead(proteinMapFile);
	FILE* fin = fopen(proteinMapFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; i <= iMax - 1 && !feof(fin); i++ )
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
			else
			{
//debug
//if (strcmp(name, "ENSP00000353245") == 0)
//{
//	cout << "ENSP00000353245";
//}
//cout << "ReadProteinMap debug "  << i << endl;

				strcpy(tempProtein.chName, name);

				Protein* pResult = NULL;
				pResult = (Protein*) bsearch(&tempProtein, pProtein, pSize, sizeof(Protein), ProteinCompare);
				if (pResult != NULL)
				{
					int pos = pResult->iID;

					//区间H,G开头的不解析，直接填0
					//if ((chromosome.at(0) == 'H') || (chromosome.at(0) == 'G'))
					if ((chromosome[0] == 'H') || (chromosome[0] == 'G'))
					{
						strcpy((pProteinMaps + pos)->chName, name);
						(pProteinMaps + pos)->pos = UNNORMAL_POS;
					}
					else
					{
						//name复制，pos处理成位
						strcpy((pProteinMaps + pos) -> chName, name);
						(pProteinMaps + pos) -> pos  = LocationToBit(chromosome, band);
					}
				}
				else
				{}
			}
		}
		fclose(fin);
	}
	else
	{
		MsgError(proteinMapFile);
	}

//test
	//fstream fout("Data\\test\\proteinMap.test", ios::out);
	//if (fout)
	//{
	//	for (pos = 0; pos <= TOTAL_PROTEINS - 1; pos++)
	//	{
	//		fout << TotalProteinMaps[pos].chName << " " << TotalProteinMaps[pos].pos<< " "
	//			<< "\n" ;
	//	}
	//	fout.flush();
	//	fout.close();
	//}
	//else
	//{}
}

//static const int simiMax = 5192686;//5111496; //相似度文件protein.links行数
static const int proteinLink = 3281414;//2577771;
static const int BEGIN_LINE = 1306854;//2526668;
static const int END_LINE = 4588268;//5104440;
static const char* pchProteinSimilarityInputFile = "Data\\original\\protein.links.v9.0.005";
Simi proteinSimi[simiMax];
void NormalizeProteinSimilarity()
{
	MsgFunction("NormalizeProteinSimilarity");

	char first[10+PROTEIN_LENGTH] = {'\0'};
	char second[10+PROTEIN_LENGTH] = {'\0'};

	int mark = 0;

	int min = INT_MAX;
	int max = 0;
	int delta = 0;
	//Protein tempProtein;

	MsgRead(pchProteinSimilarityInputFile);
	FILE* fin = fopen(pchProteinSimilarityInputFile, "r");
	if (fin)
	{
		int i = 0;
		int j = 0;
		for (j = 0; j <= simiMax - 1 && !feof(fin); j++)
		{
			fscanf(fin, "%s %s %d", first, second, &mark);
			if (j >= BEGIN_LINE - 1 && j <= END_LINE - 1 )
			{
				strcpy(proteinSimi[i].first, first + 5);
				strcpy(proteinSimi[i].second, second + 5);
				proteinSimi[i].mark = mark;

				if (mark > max)
				{
					max = mark;
				}
				else
				{}

				if (mark < min)
				{
					min = mark;
				}
				else
				{}
				i++;
			}
			else
			{}

		}
		delta = max - min;

		fclose(fin);
	}
    else
    {
        MsgError(pchProteinSimilarityInputFile);
    }

	FILE* fout = fopen(proteinSimilarityFile, "w");
	if(fout)
	{
		float result = 0;
		int i = 0;
		for (i = 0; i <= proteinLink - 1; i++ )
		{
//debug
//if (i == 2577771)
//{
//	printf("%d\n", i);
//
//}
			result = (float)(proteinSimi[i].mark - min)/(float)delta;
			fprintf(fout, "%s,%s,%.7f\n",proteinSimi[i].first, proteinSimi[i].second, result);
		}
		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError(proteinSimilarityFile);
	}
}
