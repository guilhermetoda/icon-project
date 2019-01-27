using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour {

    private string[] positiveWords;
    private string[] negativeWords;

	public Words()
    {
        positiveWords = GoodWords();
        negativeWords = BadWords() ;
    }

    // wordType
    // 0 - Positive
    // 1 - Negative
    public string GetRandomWord(int wordType)
    {
        if (wordType == 0)
        {
            //Debug.Log("POSITIVE WORD"+positiveWords[0]);
            return GetRandomWordFromArray(positiveWords);
        }
        else
        {
            //Debug.Log("NEGATIVE WORD");
            return GetRandomWordFromArray(negativeWords);
        }
    }

    public string GetRandomWordFromArray(string[] wordsList)
    {
        //get the text component
        int randomNumber = Random.Range(0, wordsList.Length);
        return wordsList[randomNumber];
    }

    public string[] GoodWords()
    {
        string[] wordsList = new string[100];
        wordsList[0] = "welcoming";
        wordsList[1] = "safe";
        wordsList[2] = "fun";
        wordsList[3] = "joy";
        wordsList[4] = "nice";
        wordsList[5] = "care";
        wordsList[6] = "kind";
        wordsList[7] = "good";
        wordsList[8] = "rest";
        wordsList[9] = "help";
        wordsList[10] = "hope";
        wordsList[11] = "grow";
        wordsList[12] = "play";
        wordsList[13] = "team";
        wordsList[14] = "love";
        wordsList[15] = "warm";
        wordsList[16] = "aunt";
        wordsList[17] = "mom";
        wordsList[18] = "dad";
        wordsList[19] = "uncle";
        wordsList[20] = "happy";
        wordsList[21] = "worth";
        wordsList[22] = "games";
        wordsList[23] = "heart";
        wordsList[24] = "honor";
        wordsList[25] = "smart";
        wordsList[26] = "trust";
        wordsList[27] = "learn";
        wordsList[28] = "dream";
        wordsList[29] = "proud";
        wordsList[30] = "peace";
        wordsList[31] = "laugh";
        wordsList[32] = "loyal";
        wordsList[33] = "relax";
        wordsList[34] = "value";
        wordsList[35] = "renew";
        wordsList[36] = "smile";
        wordsList[37] = "sweet";
        wordsList[38] = "comfort";
        wordsList[39] = "support";
        wordsList[40] = "friends";
        wordsList[41] = "success";
        wordsList[42] = "family";
        wordsList[43] = "brother";
        wordsList[44] = "sister";
        wordsList[45] = "grandma";
        wordsList[46] = "grandpa";
        wordsList[47] = "cheerful";
        wordsList[48] = "bright";
        wordsList[49] = "cuddle";
        wordsList[50] = "inspire";
        wordsList[51] = "integrity";
        wordsList[52] = "motivation";
        wordsList[53] = "memories";
        wordsList[54] = "nurture";
        wordsList[55] = "optimistic";
        wordsList[56] = "energy";
        wordsList[57] = "passion";
        wordsList[58] = "polite";
        wordsList[59] = "reliable";
        wordsList[60] = "refresh";
        wordsList[61] = "secure";
        wordsList[62] = "serenity";
        wordsList[63] = "stability";
        wordsList[64] = "strong";
        wordsList[65] = "wealth";
        wordsList[66] = "wisdom";
        wordsList[67] = "believe";
        wordsList[68] = "acceptance";
        wordsList[69] = "achievement";
        wordsList[70] = "ambition";
        wordsList[71] = "affection";
        wordsList[72] = "amazing";
        wordsList[73] = "awesome";
        wordsList[74] = "grateful";
        wordsList[75] = "approval";
        wordsList[76] = "beautiful";
        wordsList[77] = "belonging";
        wordsList[78] = "wonderful";
        wordsList[79] = "positive";
        wordsList[80] = "connected";
        wordsList[81] = "delightful";
        wordsList[82] = "dedicated";
        wordsList[83] = "encourage";
        wordsList[84] = "excellent";
        wordsList[85] = "empower";
        wordsList[86] = "fulfilment";
        wordsList[87] = "fabulous";
        wordsList[88] = "guidance";
        wordsList[89] = "healthy";
        wordsList[90] = "harmony";
        wordsList[91] = "improvement";
        wordsList[92] = "imagination";
        wordsList[93] = "incredible";
        wordsList[94] = "meaningful";
        wordsList[95] = "opportunity";
        wordsList[96] = "overcome";
        wordsList[97] = "thankful";
        wordsList[98] = "understand";
        wordsList[99] = "unconditional";
        return wordsList;
    }

    public string[] BadWords()
    {
        string[] wordsList = new string[92];
        wordsList[0] = "bad";
        wordsList[1] = "cry";
        wordsList[2] = "mad";
        wordsList[3] = "lie";
        wordsList[4] = "fall";
        wordsList[5] = "evil";
        wordsList[6] = "cold";
        wordsList[7] = "hate";
        wordsList[8] = "poor";
        wordsList[9] = "boss";
        wordsList[10] = "burn";
        wordsList[11] = "work";
        wordsList[12] = "hurt";
        wordsList[13] = "loss";
        wordsList[14] = "cheat";
        wordsList[15] = "steal";
        wordsList[16] = "stress";
        wordsList[17] = "fight";
        wordsList[18] = "hard";
        wordsList[19] = "mean";
        wordsList[20] = "nasty";
        wordsList[21] = "tired";
        wordsList[22] = "upset";
        wordsList[23] = "argue";
        wordsList[24] = "fight";
        wordsList[25] = "scared";
        wordsList[26] = "break";
        wordsList[27] = "greed";
        wordsList[28] = "faulty";
        wordsList[29] = "failure";
        wordsList[30] = "fatigue";
        wordsList[31] = "lonely";
        wordsList[32] = "difficult";
        wordsList[33] = "tough";
        wordsList[34] = "essays";
        wordsList[35] = "despair";
        wordsList[36] = "reports";
        wordsList[37] = "isolation";
        wordsList[38] = "rejection";
        wordsList[39] = "anxiety";
        wordsList[40] = "disrupt";
        wordsList[41] = "budgets";
        wordsList[42] = "helpless";
        wordsList[43] = "terrible";
        wordsList[44] = "unsure";
        wordsList[45] = "disagree";
        wordsList[46] = "spread";
        wordsList[47] = "overtime";
        wordsList[48] = "negative";
        wordsList[49] = "destroy";
        wordsList[50] = "defeat";
        wordsList[51] = "shatter";
        wordsList[52] = "annoying";
        wordsList[53] = "demotion";
        wordsList[54] = "deprived";
        wordsList[55] = "hopeless";
        wordsList[56] = "deadlines";
        wordsList[57] = "uncertainty";
        wordsList[58] = "depression";
        wordsList[59] = "paradigm";
        wordsList[60] = "controversy";
        wordsList[61] = "gossip";
        wordsList[62] = "weight";
        wordsList[63] = "patience";
        wordsList[64] = "exhaustion";
        wordsList[65] = "commute";
        wordsList[66] = "innovative";
        wordsList[67] = "products";
        wordsList[68] = "storage";
        wordsList[69] = "synergy";
        wordsList[70] = "tactical";
        wordsList[71] = "ubiquitous";
        wordsList[72] = "proactive";
        wordsList[73] = "demand";
        wordsList[74] = "resources";
        wordsList[75] = "frictionless";
        wordsList[76] = "streamline";
        wordsList[77] = "strategize";
        wordsList[78] = "orchestrate";
        wordsList[79] = "myocardinate";
        wordsList[80] = "spreadsheets";
        wordsList[81] = "professionally";
        wordsList[82] = "distinctively";
        wordsList[83] = "conveniently";
        wordsList[84] = "fungibly";
        wordsList[85] = "expedite";
        wordsList[86] = "exploit";
        wordsList[87] = "fabricate";
        wordsList[88] = "implement";
        wordsList[89] = "cooperative";
        wordsList[90] = "mindshare";
        wordsList[91] = "spreadsheets";
        return wordsList;

    }
}
