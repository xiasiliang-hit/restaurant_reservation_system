#include "Test.h"

void LocationMatchTest2()
{
    MsgFunction("LocationMatchTest2");

	MorbidLoc m;
	ProteinLoc p;

    FILE* fout = NULL;
    fout = fopen("Data\\test\\match_adjust_bit_2.test", "w");
	if (fout)
	{
		int excN = 0;
		int i = 0;
		for (i = 0; i <= TOTAL_PHENOTYPES - 1; ++i)
		{
		    fprintf(fout, "%s", TotalPhenotypes[i].chName );
			int k = 0;
			for (k = 0; k <= pointerMorbidLocs[i].offset - 1 ; k++)
			{
				int pos = pointerMorbidLocs[i].start + k;
				m = TotalMorbidLocs[pos];
                fprintf(fout, "[%s,%s]:", BitToLocation(m.start), BitToLocation(m.end));
			}

			bool exceptionFlag = false;
			int j = 0;
			for (j = 0; j <= pointerPhenotypeProteins[i].offset - 1; j++)
			{
				int pos = pointerPhenotypeProteins[i].start + j;

				int proteinID = TotalPhenotypeProtein[pos];
				p = TotalProteinLocs[proteinID];

				bool match= false;

                int k = 0;
				for (k = 0; k <= pointerMorbidLocs[i].offset - 1; k++)
				{
					int pos = pointerMorbidLocs[i].start + k;
					m = TotalMorbidLocs[pos];

					if (isLocationMatch2(m, p) == true)
					{
					    fprintf(fout, "1,");
						match = true;
						break;
					}
					else
					{}
				}

				if (match == false)
				{
				    fprintf(fout, "%s[%s],", ProteinIDToName(proteinID), BitToLocation(p.pos));
                    exceptionFlag = true;
				}
				else
				{}
			}

			fprintf(fout, "\n");

			if (exceptionFlag == true)
			{
				excN++;
			}
		}
		fprintf(fout, "no match:%d\n", excN);
		printf("no match:%d\n", excN);

		fflush(fout);
		fclose(fout);
	}
	else
	{
	    printf("error");
	}
}
