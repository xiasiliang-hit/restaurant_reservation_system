#include "LocationMap.h"
#include "Test.h"

unsigned int mask[CATAGORY] = {
	MASK_CHRO,
	MASK_CHRO | MASK_ARM,
	MASK_CHRO | MASK_ARM | MASK_SUBONE,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO | MASK_SUBTHREE,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO | MASK_SUBTHREE | MASK_SUBFOUR
};

MorbidLocPointer pointerMorbidLocs[TOTAL_PHENOTYPES];
MorbidLoc TotalMorbidLocs[TOTAL_MORBIDLOCS];

ProteinLoc TotalProteinLocs[TOTAL_PROTEINS];

bool isLocationMatch(const MorbidMap pM, const ProteinMap pP)
{
//debug
//if (strcmp(pM.chName, "603554") == 0)
//{
//	cout << "debug: isLocationMatch 603554" << endl;
//}

	bool isMatch = false;
	unsigned int maskArm = MASK_CHRO | MASK_ARM;

	if (((pP.pos & maskArm) == (pM.end & maskArm) || (pP.pos & maskArm) == (pM.start & maskArm))
		&& pP.pos >= pM.start && pP.pos <= pM.end)
	{
		isMatch = true;
	}
	else
	{
		int i = 0;
		for (i = 0; i<= CATAGORY - 1; i++)
		{
			unsigned int maskNow = mask[i];

			if((pP.pos & maskNow) == (pM.end & maskNow) && (pM.end & maskNow) == pM.end)
			{
				isMatch = true;
				break;
			}
			else
			{}
		}
	}

	return isMatch;
}
void CreateMapFile()
{
	MsgFunction("CreateMapFile");

	LocationMatchTest();
	LocationAdjust();
	LocationMatchTest();

	int i = 0;
	for (i = 0; i <= TOTAL_PROTEINS - 1; i++)
	{
		TotalProteinLocs[i].pos = TotalProteinMaps[i].pos;
		int j = 0;
		for (j = 0; j <= CATAGORY - 1; j++)
		{
			if ((TotalProteinLocs[i].pos & mask[j]) == (TotalProteinLocs[i].pos) )
			{
				TotalProteinLocs[i].maskPos = j;
				break;
			}
			else
			{}
		}
	}

	int tCount = 0;

	for (i = 0; i <= TOTAL_PHENOTYPES - 1; ++i)
	{
		int rowCount = 0;

		pointerMorbidLocs[i].start = tCount;

		int j = 0;
		for (j = 0; j <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][j].chName, "") != 0; j++)
		{
			TotalMorbidLocs[tCount].start = TotalMorbidMaps[i][j].start;
			TotalMorbidLocs[tCount].end= TotalMorbidMaps[i][j].end;

			int k = 0;
			for (k = 0; k <= CATAGORY - 1; k++)
			{
				if ((TotalMorbidLocs[tCount].start & mask[k]) == (TotalMorbidLocs[tCount].start))
				{
					TotalMorbidLocs[tCount].maskPosStart= k;
					break;
				}
				else
				{}
			}

			//int k = 0;
			for (k = 0; k <= CATAGORY - 1; k++)
			{
				if ((TotalMorbidLocs[tCount].end & mask[k]) == (TotalMorbidLocs[tCount].end))
				{
					TotalMorbidLocs[tCount].maskPosEnd= k;
					break;
				}
			}

			rowCount++;
			tCount++;
		}
		pointerMorbidLocs[i].offset = rowCount; //tCount - TotalMorbidLocPointers[i].start;
	}

	printf("->TOTAL_MORBIDLOCS:%d\n", tCount);

	MsgWrite(proteinLocsFileBin);
	FILE* pFile = fopen(proteinLocsFileBin, "wb");
	if (pFile)
	{
		fwrite(TotalProteinLocs, sizeof(ProteinLoc), TOTAL_PROTEINS, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(proteinLocsFileBin);
	}


	MsgWrite(phenotypeLocsFileBin);
	pFile = fopen(phenotypeLocsFileBin, "wb");
	if (pFile)
	{
		fwrite(TotalMorbidLocs, sizeof(MorbidLoc), TOTAL_MORBIDLOCS, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(phenotypeLocsFileBin);
	}

	MsgWrite(phenotypeLocsPointerFileBin);
	pFile = fopen(phenotypeLocsPointerFileBin, "wb");
	if (pFile)
	{
		fwrite(pointerMorbidLocs, sizeof(MorbidLocPointer), TOTAL_PHENOTYPES, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(proteinLocsFileBin);
	}
//test
	FILE* fout = fopen("Data\\test\\morbidlocs.test", "w");
	FILE* fout2 = fopen("Data\\test\\morbidlocspointer.test", "w");

	if (fout )
	{
        int i =0;
		for (i =0; i<=TOTAL_MORBIDLOCS-1; i++)
		{
			fprintf(fout, "[%s,%s]\n",BitToLocation(TotalMorbidLocs[i].start), BitToLocation(TotalMorbidLocs[i].end));

		}
	}

	if (fout2)
	{
        int i =0;
		for (i =0; i<=TOTAL_PHENOTYPES-1; i++)
		{
			fprintf(fout2, "(%d, %d)\n", pointerMorbidLocs[i].start, pointerMorbidLocs[i].offset);
		}
	}
    fclose(fout);
	fclose(fout2);
}
