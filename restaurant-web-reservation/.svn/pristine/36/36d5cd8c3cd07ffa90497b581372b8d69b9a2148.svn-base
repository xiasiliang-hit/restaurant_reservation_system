#include "Interaction.h"

int cmpProteinSimi(const void * a, const void * b)
{
	return (*(ProteinSimilarityItem*)a).proteinBID - (*(ProteinSimilarityItem*)b).proteinBID;
}

/*
*返回两个蛋白质的相似度，如果找不到，则返回 0
*/
float getProteinSimilarity(int proteinAID,int proteinBID)
{
	float returnValue = 0.0f;
	if (proteinAID >= 0 && proteinBID >= 0)
	{
		int position = proteinSimiIndexs[proteinAID];
		ProteinSimilarityItem tempProtein;
		tempProtein.proteinBID = proteinBID;
		if (position != -1)
		{
			int temp = proteinAID + 1;
			while (proteinSimiIndexs[temp] == -1)
			{
				temp++;
			}

			int next_pos = 0;
			if (temp <= TOTAL_PROTEINS - 1)
			{
				next_pos = proteinSimiIndexs[temp];
			}
			else
			{
				next_pos = TOTAL_PROTEIN_SIMILARITY;
			}
			ProteinSimilarityItem * ptr =
				(ProteinSimilarityItem*)bsearch(&tempProtein,&proteinSimilarity[position],next_pos - position,sizeof(proteinSimilarity[0]),(int(*)(const void *, const void *))cmpProteinSimi);
			if (ptr != NULL)
			{
				returnValue = ptr->similarity;
			}
			else
			{}
		}
		else
		{}
	}
	else
	{}

	return returnValue;
}

void CreateProteinInteractionMatrix()                 ///////////////////////////////////
{
	MsgFunction("CreateProteinInteractionMatrixFile");
    int step_i = 0;
	for (step_i = 0; step_i < TOTAL_PROTEINS; ++step_i)
	{
	    int step_j  = 0;
		for (step_j = 0; step_j < TOTAL_PHENOTYPES; ++step_j)
		{
			//取最大的
			/*interactionMatrix[TotalProteins[step_i].iID][TotalPhenotypes[step_j].iID] =
				proteinSimilarity[TotalProteins[step_i].iID][phenotypeProtein[TotalPhenotypes[step_j].iID][0]];*/
			interactionMatrix[TotalProteins[step_i].iID][TotalPhenotypes[step_j].iID] = 0;

			float bigest = 0;

            int j = 0;
            for (j = 0; j <= pointerPhenotypeProteins[step_j].offset - 1; j++)
            {
				int pos = pointerPhenotypeProteins[step_j].start + j;
				int proteinID = TotalPhenotypeProtein[pos];

				float now = getProteinSimilarity(TotalProteins[step_i].iID,proteinID);
				if (bigest < now)
				{
					bigest = now;
				}
				else
				{}
                //interactionMatrix[TotalProteins[step_i].iID][TotalPhenotypes[step_j].iID] +=
                //	proteinSimilarity[TotalProteins[step_i].iID][phenotypeProtein[TotalPhenotypes[step_j].iID][i]];

			}
			//interactionMatrix[TotalProteins[step_i].iID][TotalPhenotypes[step_j].iID] /= i;
			interactionMatrix[TotalProteins[step_i].iID][TotalPhenotypes[step_j].iID] = bigest;
		}
	}

	MsgWrite(interactionMatrixFileBin);
	FILE* pFile = fopen(interactionMatrixFileBin, "wb");
	if (pFile)
	{
		fwrite(interactionMatrix, sizeof(float), TOTAL_PROTEINS * TOTAL_PHENOTYPES,
			pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		printf("%s open error\n", interactionMatrixFileBin);
	}
}

int TotalPhenotypeMatchProtein[TOTAL_PHENOTYPEMATCHPROTEINS];
PhenotypeMatchProteinPointer pointerPhenotypeMatchProtein[TOTAL_PHENOTYPES];
void CreatePhenotypeMatchProteinRelationFile()
{
	MsgFunction("CreatePhenotypeMatchProteinRelationFile");
	int countRow = 0;
	int step_i = 0;
		for (step_i = 0; step_i <= TOTAL_PHENOTYPES - 1; ++step_i)
		{
			pointerPhenotypeMatchProtein[step_i].start = countRow;

			int iPhenotypeID = TotalPhenotypes[step_i].iID;
			int countOffset = 0;

			int step_j = 0;
			for (step_j = 0; step_j <= TOTAL_PROTEINS - 1; ++step_j)
			{
				int iProteinID = TotalProteins[step_j].iID;
				ProteinLoc p = TotalProteinLocs[iProteinID];

				bool isMatch = false;

				int k = 0;
				for (k = 0; k <= pointerMorbidLocs[step_i].offset - 1 ; k++)
				{
					int pos = pointerMorbidLocs[step_i].start + k;
					MorbidLoc m = TotalMorbidLocs[pos];

					if (isLocationMatch2(m, p) == true)
					{
						isMatch = true;

						break;
					}
					else
					{}
				}

				if (isMatch == true)
				{
					TotalPhenotypeMatchProtein[countRow] = iProteinID;
					countRow++;
					countOffset++;
				}
				else
				{}
			}

			pointerPhenotypeMatchProtein[step_i].offset = countOffset;
		}

	printf("->TOTAL_PHENOTYPEMATCHPROTEINS: %d\n", countRow);

	FILE* pFileOut = fopen(phenotypeMatchProteinFileBin, "wb");
	MsgWrite(phenotypeMatchProteinFileBin);
	if (pFileOut)
	{
		fwrite(TotalPhenotypeMatchProtein, sizeof(int), TOTAL_PHENOTYPEMATCHPROTEINS, pFileOut);
		fflush(pFileOut);
		fclose(pFileOut);
	}
	else
	{
		MsgError(phenotypeMatchProteinFileBin);
	}

	pFileOut = fopen(pointerPhenotypeMatchProteinFileBin, "wb");
	MsgWrite(pointerPhenotypeMatchProteinFileBin);
	if (pFileOut)
	{
		fwrite(pointerPhenotypeMatchProtein, sizeof(PhenotypeMatchProteinPointer), TOTAL_PHENOTYPES, pFileOut);
		fflush(pFileOut);
		fclose(pFileOut);
	}
	else
	{
		MsgError(pointerPhenotypeMatchProteinFileBin);
	}
}
