using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {


	public Camera cam;
	public GameObject bad_word;
	public GameObject good_word;

	public GameObject newObject;
	//public GameObject food2; 
	private float maxWidth;
	private Text foodText;
	public Text question;
	private int Score;
	public float word_time;
	bool col_check;

	private string[,] solutions = new string[100,2] {
		{"What is a word to describe somebody who is talented beyond their age?","precocious"},
		{"What is a word to describe a leader gaining support by speaking to peoples interests?","demagogue"},
		{"What is a word to describe something out-of-date?", "anachronistic"},
		{"What is a word for the opposite of loyal?","perfidious"},
		{"What is another word for impulsive?","impetuous"},
		{"What means to have a strong and sharp taste?", "acrid"},
		{"What means to scold or reprimand?", "admonish"},
		{"What is a word for someone who for a person cause or idea?", "advoacate" },
		{"What means to be serious or sincere?", "earnest"},
		{"What word means to give supporting evidence?","substantiate"},
		{"What word means unbiased or fair?", "impartial"},
		{"What is a word for new fresh or original", "novel"},
		{"What is a word for someone who is devoutly religous?","pious"},
		{"What is a word for something small or insignifigant?", "petty"},
		{"What word means based or observation or experiment?", "empirical"},
		{"What word means longing for the past?", "nostaligic"},
		{"What word means to disprove?", "refute"},
		{"What word means to make new again?", "restore"},
		{"What word means fixed or not moving?", "static"},
		{"What is a word for something difficult to understand or partially hidden?", "obscure"},
		{"What word means wealthy?", "affluent"},
		{"What is a word meaning lively or spirited?", "animated"},
		{"What is another word for boring?", "tedious"},
		{"What word means emotionally hardened?", "callous"},
		{"What word means lack of intelligence?", "fatuous"},
		{"What word means easily annoyed?", "petulant"},
		{"What word means not easily annoyed?", "placid"},
		{"What is a word for someone gloomy in character?", "somber"},
		{"What is a word for someone beliveing the worst of human nature?", "cynical"},
		{"What word means strongly opposed?", "averse"},
		{"What word means a courteous regard for people's feelings?","deference"},
		{"What word means to show high-spirited merriment?", "jovial"},
		{"What word means lacking energy or will?", "passive"},
		{"What word means to treat others with arrogance?", "patronize"},
		{"What is a word for someone who likes to argue?", "quarrelsome"},
		{"What is a word for someone who shows little to know emotion?","apathetic"},
		{"What word means outwardly straightfoward?", "candid"},
		{"What is a word for chaos or lack or governement?", "anarchy"},
		{"What is another word for to worsen or decline?","deteriorate"},
		{"What word means a clear explanation?", "exposition"},
		{"What is another word for a difficult sitaution or dilemma?", "predicament"},
		{"What is another word for friendly?", "amiable"},
		{"What is another word for spontaneous?" , "impromptu"},
		{"What word means to cut short?", "truncate"},
		{"What is another word for clear?", "lucid"},
		{"What is another word for ridiculous or silly?", "ludicrous"},
		{"What word means to climb?", "scale"},
		{"What is another word for muscular?", "brawny"},
		{"What word means to no longer valid?", "obsolete"},
		{"What is another word for worship?", "revere"},
		{"What is another word for forceful or unflexible?", "adamant" },
		{"What is another word for course or granular?", "gritty"},
		{"What is another word for harmless?", "benign"},
		{"What is another word for lasting?", "enduring"},
		{"What word means to scold or criticize?", "berate"},
		{"What word means easily fooled?", "gullible"},
		{"What is another word the top most point?", "pinnacle"},
		{"What word means flimsy frail or delicate?", "wispy"},
		{"What is anther word for vulnerable?", "suscepitble"},
		{"What is a word for a brief amusing story?", "anecdote"},
		{"What word means to wander off subject?", "digress"},
		{"What word means native to an area?", "indigenous"},
		{"What is another word for flexible?", "maleable"},
		{"What is another word for pompous or self-important?","pretentious"},
		{"What word means not clear?", "incoherent"},
		{"What word means to examine carefully?" ,"scrutinize" },
		{"What is another word for false?", "fallicious"},
		{"What is another word for calm and collected?", "poised"},
		{"What word means a collection of old records?", "archives"},
		{"What is another word for procedure or code of behaivor?", "protocol"},
		{"What word means come together?", "merge"},
		{"What is another word for diziness?" , "vertigo"},
		{"Whats another word for someone who hates the rest of the world?", "misanthrope"},
		{"What word means to reduce or lessen?" , "abate"},
		{"What word means to distribute or set aside?", "allocate"},
		{"What word means thrifty or cheap?", "frugal"},
		{"What word means to be excessively instructive?", "didactic"},
		{"What is another word for fearless or adventurous?","intrepid"},
		{"What word means to have identification with the feelings of others?", "empathy"},
		{"What word means to make void or invalid?", "annul"},
		{"What is a person who complies with accepted rules and customs?", "conformist"},
		{"Word used to describe someone who is arrogant and condescending?","haughty"},
		{"What word means to unnecessarily delay postpone or put off?", "procrastinate"},
		{"What word means friendly or helpful?","benevolent" },
		{"What is another word for excessivly dry?", "arrid"},
		{"What is another word for careful or cautious?", "wary"},
		{"What word means to shorten or abbridge?" ,"abbreviate"},
		{"What word means in a state of sluggishness or apathy?", "lethargic"},
		{"What word means to feel regret?", "compunction"},
		{"What is another word for eagerness?", "alacrity"},
		{"What word means hard to comprehend?", "abtruse"},
		{"What word means to not agreeing or not in harmony with?", "discordant"},
		{"What is a word for an example that is a perfect pattern or model?", "paradigm"},
		{"What word means deserving blame?", "culpable"},
		{"What word means hidden but capable of being exposed?", "latent"},
		{"What is a word for a person who rebels?", "insuregent"},
		{"What word means a mixture of differing things?", "medley"},
		{"What word means high praise?", "acclaim"},
		{"What word means to insert between other things?", "interject"},
		{"What is a word for overindulgence in food or drink?", "gluttony"},
		/*{"What word means to to scatter?", "disperse"},
		{"What word means  very thin?", "emaciated"},
		{"What word means a false identity?", "alias" },
		{"What word means extremely joyful or happy?", "jubilant"},
		{"What word means to trick or decieve", "beguile"},
		{"What word means to spread widely?", "disseminate"},
		{"What word means to give in return?", "reciprocate"},
		{"What word means experiencing through another?", "vicarious"},
		{"What word means charmingly old-fashioned?", "quaint"},
		{"What word means to steal money by falsifying records?", "embezzle"},
		{"What word means having a pointed sharp smell?", "pungent"},
		{"What word means calm?", "tranquil"},
		{"What word means to revoke formally?", "abrogate"},
		{"What word means to add details to enhance?","embellish"},
		{"What word means expressed without words?", "tacit"},
		{"What word means requiring tremendous energy or stamina?", "strenuous"}*/
	};

	// Use this for initialization
	void Start () {
		Debug.Log("Hello");
		//score = 0;
		if (cam == null)
		{
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x; 
		StartCoroutine (DisplayInstructions ());
	}

	IEnumerator DisplayInstructions()
	{
		question.text = "Tutorial";
		yield return new WaitForSeconds (2);
		question.text = "Use your cursor to move the monster left and right.";
		yield return new WaitForSeconds (4);
		question.text = "Vocabulary questions are displayed here.";
		yield return new WaitForSeconds (2);
		question.text = "Example: " + solutions [60, 0];
		yield return new WaitForSeconds (5);
		question.text = "Catch the word with your monster";
		Vector3 spawnPosition = new Vector3 (
			Random.Range (-maxWidth / 2, maxWidth / 2),
			transform.position.y,
			-1.0f);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject newObject = (GameObject)Instantiate (good_word, spawnPosition, spawnRotation);
		TextMesh hello = newObject.transform.GetComponent<TextMesh> ();
		hello.text = solutions [60, 1];
		hello.fontSize = 8;
		yield return new WaitForSeconds (5);
		question.text = "Great! Have fun";
		SceneManager.LoadScene ("scene2"); 
	}



}
