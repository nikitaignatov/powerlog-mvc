//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3 2012-10-23 20:51:16

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;

namespace PowerLog.Parser
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4")]
[System.CLSCompliant(false)]
public partial class PowerLogGrammarLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int T__16=16;
	public const int T__17=17;
	public const int T__18=18;
	public const int DIGIT=4;
	public const int FLOAT=5;
	public const int FR=6;
	public const int FTL=7;
	public const int LETTER=8;
	public const int MAX=9;
	public const int NOTE=10;
	public const int NUMBER=11;
	public const int TF=12;
	public const int WORD=13;
	public const int WS=14;
	public const int X=15;

    // delegates
    // delegators

	public PowerLogGrammarLexer()
	{
		OnCreated();
	}

	public PowerLogGrammarLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public PowerLogGrammarLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void EnterRule_T__16();
	partial void LeaveRule_T__16();

	// $ANTLR start "T__16"
	[GrammarRule("T__16")]
	private void mT__16()
	{
		EnterRule_T__16();
		EnterRule("T__16", 1);
		TraceIn("T__16", 1);
		try
		{
			int _type = T__16;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:9:7: ( '(' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:9:9: '('
			{
			DebugLocation(9, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__16", 1);
			LeaveRule("T__16", 1);
			LeaveRule_T__16();
		}
	}
	// $ANTLR end "T__16"

	partial void EnterRule_T__17();
	partial void LeaveRule_T__17();

	// $ANTLR start "T__17"
	[GrammarRule("T__17")]
	private void mT__17()
	{
		EnterRule_T__17();
		EnterRule("T__17", 2);
		TraceIn("T__17", 2);
		try
		{
			int _type = T__17;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:10:7: ( ')' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:10:9: ')'
			{
			DebugLocation(10, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__17", 2);
			LeaveRule("T__17", 2);
			LeaveRule_T__17();
		}
	}
	// $ANTLR end "T__17"

	partial void EnterRule_T__18();
	partial void LeaveRule_T__18();

	// $ANTLR start "T__18"
	[GrammarRule("T__18")]
	private void mT__18()
	{
		EnterRule_T__18();
		EnterRule("T__18", 3);
		TraceIn("T__18", 3);
		try
		{
			int _type = T__18;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:11:7: ( '-' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:11:9: '-'
			{
			DebugLocation(11, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__18", 3);
			LeaveRule("T__18", 3);
			LeaveRule_T__18();
		}
	}
	// $ANTLR end "T__18"

	partial void EnterRule_DIGIT();
	partial void LeaveRule_DIGIT();

	// $ANTLR start "DIGIT"
	[GrammarRule("DIGIT")]
	private void mDIGIT()
	{
		EnterRule_DIGIT();
		EnterRule("DIGIT", 4);
		TraceIn("DIGIT", 4);
		try
		{
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:90:5: ( '\\u0030' .. '\\u0039' | '\\u0660' .. '\\u0669' | '\\u06f0' .. '\\u06f9' | '\\u0966' .. '\\u096f' | '\\u09e6' .. '\\u09ef' | '\\u0a66' .. '\\u0a6f' | '\\u0ae6' .. '\\u0aef' | '\\u0b66' .. '\\u0b6f' | '\\u0be7' .. '\\u0bef' | '\\u0c66' .. '\\u0c6f' | '\\u0ce6' .. '\\u0cef' | '\\u0d66' .. '\\u0d6f' | '\\u0e50' .. '\\u0e59' | '\\u0ed0' .. '\\u0ed9' | '\\u1040' .. '\\u1049' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
			{
			DebugLocation(90, 5);
			if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='\u0660' && input.LA(1)<='\u0669')||(input.LA(1)>='\u06F0' && input.LA(1)<='\u06F9')||(input.LA(1)>='\u0966' && input.LA(1)<='\u096F')||(input.LA(1)>='\u09E6' && input.LA(1)<='\u09EF')||(input.LA(1)>='\u0A66' && input.LA(1)<='\u0A6F')||(input.LA(1)>='\u0AE6' && input.LA(1)<='\u0AEF')||(input.LA(1)>='\u0B66' && input.LA(1)<='\u0B6F')||(input.LA(1)>='\u0BE7' && input.LA(1)<='\u0BEF')||(input.LA(1)>='\u0C66' && input.LA(1)<='\u0C6F')||(input.LA(1)>='\u0CE6' && input.LA(1)<='\u0CEF')||(input.LA(1)>='\u0D66' && input.LA(1)<='\u0D6F')||(input.LA(1)>='\u0E50' && input.LA(1)<='\u0E59')||(input.LA(1)>='\u0ED0' && input.LA(1)<='\u0ED9')||(input.LA(1)>='\u1040' && input.LA(1)<='\u1049'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}


			}

		}
		finally
		{
			TraceOut("DIGIT", 4);
			LeaveRule("DIGIT", 4);
			LeaveRule_DIGIT();
		}
	}
	// $ANTLR end "DIGIT"

	partial void EnterRule_NUMBER();
	partial void LeaveRule_NUMBER();

	// $ANTLR start "NUMBER"
	[GrammarRule("NUMBER")]
	private void mNUMBER()
	{
		EnterRule_NUMBER();
		EnterRule("NUMBER", 5);
		TraceIn("NUMBER", 5);
		try
		{
			int _type = NUMBER;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:106:7: ( ( '0' .. '9' )+ )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:106:9: ( '0' .. '9' )+
			{
			DebugLocation(106, 9);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:106:9: ( '0' .. '9' )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_0 = input.LA(1);

				if (((LA1_0>='0' && LA1_0<='9')))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
					{
					DebugLocation(106, 9);
					input.Consume();


					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NUMBER", 5);
			LeaveRule("NUMBER", 5);
			LeaveRule_NUMBER();
		}
	}
	// $ANTLR end "NUMBER"

	partial void EnterRule_FLOAT();
	partial void LeaveRule_FLOAT();

	// $ANTLR start "FLOAT"
	[GrammarRule("FLOAT")]
	private void mFLOAT()
	{
		EnterRule_FLOAT();
		EnterRule("FLOAT", 6);
		TraceIn("FLOAT", 6);
		try
		{
			int _type = FLOAT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:108:7: ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* | '.' ( '0' .. '9' )+ )
			int alt5=2;
			try { DebugEnterDecision(5, false);
			int LA5_0 = input.LA(1);

			if (((LA5_0>='0' && LA5_0<='9')))
			{
				alt5 = 1;
			}
			else if ((LA5_0=='.'))
			{
				alt5 = 2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 5, 0, input);
				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:108:11: ( '0' .. '9' )+ '.' ( '0' .. '9' )*
				{
				DebugLocation(108, 11);
				// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:108:11: ( '0' .. '9' )+
				int cnt2=0;
				try { DebugEnterSubRule(2);
				while (true)
				{
					int alt2=2;
					try { DebugEnterDecision(2, false);
					int LA2_0 = input.LA(1);

					if (((LA2_0>='0' && LA2_0<='9')))
					{
						alt2 = 1;
					}


					} finally { DebugExitDecision(2); }
					switch (alt2)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
						{
						DebugLocation(108, 11);
						input.Consume();


						}
						break;

					default:
						if (cnt2 >= 1)
							goto loop2;

						EarlyExitException eee2 = new EarlyExitException( 2, input );
						DebugRecognitionException(eee2);
						throw eee2;
					}
					cnt2++;
				}
				loop2:
					;

				} finally { DebugExitSubRule(2); }

				DebugLocation(108, 23);
				Match('.'); 
				DebugLocation(108, 27);
				// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:108:27: ( '0' .. '9' )*
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, false);
					int LA3_0 = input.LA(1);

					if (((LA3_0>='0' && LA3_0<='9')))
					{
						alt3 = 1;
					}


					} finally { DebugExitDecision(3); }
					switch ( alt3 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
						{
						DebugLocation(108, 27);
						input.Consume();


						}
						break;

					default:
						goto loop3;
					}
				}

				loop3:
					;

				} finally { DebugExitSubRule(3); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:109:11: '.' ( '0' .. '9' )+
				{
				DebugLocation(109, 11);
				Match('.'); 
				DebugLocation(109, 15);
				// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:109:15: ( '0' .. '9' )+
				int cnt4=0;
				try { DebugEnterSubRule(4);
				while (true)
				{
					int alt4=2;
					try { DebugEnterDecision(4, false);
					int LA4_0 = input.LA(1);

					if (((LA4_0>='0' && LA4_0<='9')))
					{
						alt4 = 1;
					}


					} finally { DebugExitDecision(4); }
					switch (alt4)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
						{
						DebugLocation(109, 15);
						input.Consume();


						}
						break;

					default:
						if (cnt4 >= 1)
							goto loop4;

						EarlyExitException eee4 = new EarlyExitException( 4, input );
						DebugRecognitionException(eee4);
						throw eee4;
					}
					cnt4++;
				}
				loop4:
					;

				} finally { DebugExitSubRule(4); }


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FLOAT", 6);
			LeaveRule("FLOAT", 6);
			LeaveRule_FLOAT();
		}
	}
	// $ANTLR end "FLOAT"

	partial void EnterRule_X();
	partial void LeaveRule_X();

	// $ANTLR start "X"
	[GrammarRule("X")]
	private void mX()
	{
		EnterRule_X();
		EnterRule("X", 7);
		TraceIn("X", 7);
		try
		{
			int _type = X;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:112:7: ( 'x' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:112:9: 'x'
			{
			DebugLocation(112, 9);
			Match('x'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("X", 7);
			LeaveRule("X", 7);
			LeaveRule_X();
		}
	}
	// $ANTLR end "X"

	partial void EnterRule_MAX();
	partial void LeaveRule_MAX();

	// $ANTLR start "MAX"
	[GrammarRule("MAX")]
	private void mMAX()
	{
		EnterRule_MAX();
		EnterRule("MAX", 8);
		TraceIn("MAX", 8);
		try
		{
			int _type = MAX;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:114:7: ( 'max' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:114:9: 'max'
			{
			DebugLocation(114, 9);
			Match("max"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MAX", 8);
			LeaveRule("MAX", 8);
			LeaveRule_MAX();
		}
	}
	// $ANTLR end "MAX"

	partial void EnterRule_FTL();
	partial void LeaveRule_FTL();

	// $ANTLR start "FTL"
	[GrammarRule("FTL")]
	private void mFTL()
	{
		EnterRule_FTL();
		EnterRule("FTL", 9);
		TraceIn("FTL", 9);
		try
		{
			int _type = FTL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:115:7: ( 'ftl' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:115:9: 'ftl'
			{
			DebugLocation(115, 9);
			Match("ftl"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FTL", 9);
			LeaveRule("FTL", 9);
			LeaveRule_FTL();
		}
	}
	// $ANTLR end "FTL"

	partial void EnterRule_FR();
	partial void LeaveRule_FR();

	// $ANTLR start "FR"
	[GrammarRule("FR")]
	private void mFR()
	{
		EnterRule_FR();
		EnterRule("FR", 10);
		TraceIn("FR", 10);
		try
		{
			int _type = FR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:116:7: ( 'fr' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:116:9: 'fr'
			{
			DebugLocation(116, 9);
			Match("fr"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FR", 10);
			LeaveRule("FR", 10);
			LeaveRule_FR();
		}
	}
	// $ANTLR end "FR"

	partial void EnterRule_TF();
	partial void LeaveRule_TF();

	// $ANTLR start "TF"
	[GrammarRule("TF")]
	private void mTF()
	{
		EnterRule_TF();
		EnterRule("TF", 11);
		TraceIn("TF", 11);
		try
		{
			int _type = TF;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:117:7: ( 'tf' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:117:9: 'tf'
			{
			DebugLocation(117, 9);
			Match("tf"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TF", 11);
			LeaveRule("TF", 11);
			LeaveRule_TF();
		}
	}
	// $ANTLR end "TF"

	partial void EnterRule_NOTE();
	partial void LeaveRule_NOTE();

	// $ANTLR start "NOTE"
	[GrammarRule("NOTE")]
	private void mNOTE()
	{
		EnterRule_NOTE();
		EnterRule("NOTE", 12);
		TraceIn("NOTE", 12);
		try
		{
			int _type = NOTE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:118:7: ( 'note' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:118:9: 'note'
			{
			DebugLocation(118, 9);
			Match("note"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NOTE", 12);
			LeaveRule("NOTE", 12);
			LeaveRule_NOTE();
		}
	}
	// $ANTLR end "NOTE"

	partial void EnterRule_LETTER();
	partial void LeaveRule_LETTER();

	// $ANTLR start "LETTER"
	[GrammarRule("LETTER")]
	private void mLETTER()
	{
		EnterRule_LETTER();
		EnterRule("LETTER", 13);
		TraceIn("LETTER", 13);
		try
		{
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:123:5: ( '\\u0024' | '\\u0041' .. '\\u005a' | '\\u005f' | '\\u0061' .. '\\u007a' | '\\u00c0' .. '\\u00d6' | '\\u00d8' .. '\\u00f6' | '\\u00f8' .. '\\u00ff' | '\\u0100' .. '\\u1fff' | '\\u3040' .. '\\u318f' | '\\u3300' .. '\\u337f' | '\\u3400' .. '\\u3d2d' | '\\u4e00' .. '\\u9fff' | '\\uf900' .. '\\ufaff' | '.' | ',' | ':' | ';' )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
			{
			DebugLocation(123, 5);
			if (input.LA(1)=='$'||input.LA(1)==','||input.LA(1)=='.'||(input.LA(1)>=':' && input.LA(1)<=';')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z')||(input.LA(1)>='\u00C0' && input.LA(1)<='\u00D6')||(input.LA(1)>='\u00D8' && input.LA(1)<='\u00F6')||(input.LA(1)>='\u00F8' && input.LA(1)<='\u1FFF')||(input.LA(1)>='\u3040' && input.LA(1)<='\u318F')||(input.LA(1)>='\u3300' && input.LA(1)<='\u337F')||(input.LA(1)>='\u3400' && input.LA(1)<='\u3D2D')||(input.LA(1)>='\u4E00' && input.LA(1)<='\u9FFF')||(input.LA(1)>='\uF900' && input.LA(1)<='\uFAFF'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}


			}

		}
		finally
		{
			TraceOut("LETTER", 13);
			LeaveRule("LETTER", 13);
			LeaveRule_LETTER();
		}
	}
	// $ANTLR end "LETTER"

	partial void EnterRule_WORD();
	partial void LeaveRule_WORD();

	// $ANTLR start "WORD"
	[GrammarRule("WORD")]
	private void mWORD()
	{
		EnterRule_WORD();
		EnterRule("WORD", 14);
		TraceIn("WORD", 14);
		try
		{
			int _type = WORD;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:138:7: ( LETTER ( LETTER | DIGIT )* )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:138:9: LETTER ( LETTER | DIGIT )*
			{
			DebugLocation(138, 9);
			mLETTER(); 
			DebugLocation(138, 15);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:138:15: ( LETTER | DIGIT )*
			try { DebugEnterSubRule(6);
			while (true)
			{
				int alt6=2;
				try { DebugEnterDecision(6, false);
				int LA6_0 = input.LA(1);

				if ((LA6_0=='$'||LA6_0==','||LA6_0=='.'||(LA6_0>='0' && LA6_0<=';')||(LA6_0>='A' && LA6_0<='Z')||LA6_0=='_'||(LA6_0>='a' && LA6_0<='z')||(LA6_0>='\u00C0' && LA6_0<='\u00D6')||(LA6_0>='\u00D8' && LA6_0<='\u00F6')||(LA6_0>='\u00F8' && LA6_0<='\u1FFF')||(LA6_0>='\u3040' && LA6_0<='\u318F')||(LA6_0>='\u3300' && LA6_0<='\u337F')||(LA6_0>='\u3400' && LA6_0<='\u3D2D')||(LA6_0>='\u4E00' && LA6_0<='\u9FFF')||(LA6_0>='\uF900' && LA6_0<='\uFAFF')))
				{
					alt6 = 1;
				}


				} finally { DebugExitDecision(6); }
				switch ( alt6 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
					{
					DebugLocation(138, 15);
					input.Consume();


					}
					break;

				default:
					goto loop6;
				}
			}

			loop6:
				;

			} finally { DebugExitSubRule(6); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WORD", 14);
			LeaveRule("WORD", 14);
			LeaveRule_WORD();
		}
	}
	// $ANTLR end "WORD"

	partial void EnterRule_WS();
	partial void LeaveRule_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		EnterRule_WS();
		EnterRule("WS", 15);
		TraceIn("WS", 15);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:141:7: ( ( ' ' | '\\t' | '\\n' | '\\r' | '\\f' )+ )
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:141:9: ( ' ' | '\\t' | '\\n' | '\\r' | '\\f' )+
			{
			DebugLocation(141, 9);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:141:9: ( ' ' | '\\t' | '\\n' | '\\r' | '\\f' )+
			int cnt7=0;
			try { DebugEnterSubRule(7);
			while (true)
			{
				int alt7=2;
				try { DebugEnterDecision(7, false);
				int LA7_0 = input.LA(1);

				if (((LA7_0>='\t' && LA7_0<='\n')||(LA7_0>='\f' && LA7_0<='\r')||LA7_0==' '))
				{
					alt7 = 1;
				}


				} finally { DebugExitDecision(7); }
				switch (alt7)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:
					{
					DebugLocation(141, 9);
					input.Consume();


					}
					break;

				default:
					if (cnt7 >= 1)
						goto loop7;

					EarlyExitException eee7 = new EarlyExitException( 7, input );
					DebugRecognitionException(eee7);
					throw eee7;
				}
				cnt7++;
			}
			loop7:
				;

			} finally { DebugExitSubRule(7); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 15);
			LeaveRule("WS", 15);
			LeaveRule_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:8: ( T__16 | T__17 | T__18 | NUMBER | FLOAT | X | MAX | FTL | FR | TF | NOTE | WORD | WS )
		int alt8=13;
		try { DebugEnterDecision(8, false);
		try
		{
			alt8 = dfa8.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(8); }
		switch (alt8)
		{
		case 1:
			DebugEnterAlt(1);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:10: T__16
			{
			DebugLocation(1, 10);
			mT__16(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:16: T__17
			{
			DebugLocation(1, 16);
			mT__17(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:22: T__18
			{
			DebugLocation(1, 22);
			mT__18(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:28: NUMBER
			{
			DebugLocation(1, 28);
			mNUMBER(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:35: FLOAT
			{
			DebugLocation(1, 35);
			mFLOAT(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:41: X
			{
			DebugLocation(1, 41);
			mX(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:43: MAX
			{
			DebugLocation(1, 43);
			mMAX(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:47: FTL
			{
			DebugLocation(1, 47);
			mFTL(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:51: FR
			{
			DebugLocation(1, 51);
			mFR(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:54: TF
			{
			DebugLocation(1, 54);
			mTF(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:57: NOTE
			{
			DebugLocation(1, 57);
			mNOTE(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:62: WORD
			{
			DebugLocation(1, 62);
			mWORD(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// C:\\Users\\Bacon\\Documents\\Visual Studio 2012\\Projects\\REPO\\PowerLog\\PowerLog.Parser\\PowerLogGrammar.g3:1:67: WS
			{
			DebugLocation(1, 67);
			mWS(); 

			}
			break;

		}

	}


	#region DFA
	DFA8 dfa8;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa8 = new DFA8(this);
	}

	private class DFA8 : DFA
	{
		private const string DFA8_eotS =
			"\x4\xFFFF\x1\xD\x1\xB\x1\x10\x4\xB\x4\xFFFF\x1\xE\x1\xFFFF\x2\xB\x1\x18"+
			"\x1\x19\x1\xB\x1\x1B\x1\x1C\x2\xFFFF\x1\xB\x2\xFFFF\x1\x1E\x1\xFFFF";
		private const string DFA8_eofS =
			"\x1F\xFFFF";
		private const string DFA8_minS =
			"\x1\x9\x3\xFFFF\x1\x2E\x1\x30\x1\x24\x1\x61\x1\x72\x1\x66\x1\x6F\x4\xFFFF"+
			"\x1\x24\x1\xFFFF\x1\x78\x1\x6C\x2\x24\x1\x74\x2\x24\x2\xFFFF\x1\x65\x2"+
			"\xFFFF\x1\x24\x1\xFFFF";
		private const string DFA8_maxS =
			"\x1\xFAFF\x3\xFFFF\x2\x39\x1\xFAFF\x1\x61\x1\x74\x1\x66\x1\x6F\x4\xFFFF"+
			"\x1\xFAFF\x1\xFFFF\x1\x78\x1\x6C\x2\xFAFF\x1\x74\x2\xFAFF\x2\xFFFF\x1"+
			"\x65\x2\xFFFF\x1\xFAFF\x1\xFFFF";
		private const string DFA8_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\x1\x3\x7\xFFFF\x1\xC\x1\xD\x1\x4\x1\x5\x1\xFFFF"+
			"\x1\x6\x7\xFFFF\x1\x9\x1\xA\x1\xFFFF\x1\x7\x1\x8\x1\xFFFF\x1\xB";
		private const string DFA8_specialS =
			"\x1F\xFFFF}>";
		private static readonly string[] DFA8_transitionS =
			{
				"\x2\xC\x1\xFFFF\x2\xC\x12\xFFFF\x1\xC\x3\xFFFF\x1\xB\x3\xFFFF\x1\x1"+
				"\x1\x2\x2\xFFFF\x1\xB\x1\x3\x1\x5\x1\xFFFF\xA\x4\x2\xB\x5\xFFFF\x1A"+
				"\xB\x4\xFFFF\x1\xB\x1\xFFFF\x5\xB\x1\x8\x6\xB\x1\x7\x1\xA\x5\xB\x1\x9"+
				"\x3\xB\x1\x6\x2\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1\xFFFF\x1F08\xB"+
				"\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E\xB\x10D2\xFFFF"+
				"\x5200\xB\x5900\xFFFF\x200\xB",
				"",
				"",
				"",
				"\x1\xE\x1\xFFFF\xA\x4",
				"\xA\xF",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"\x1\x11",
				"\x1\x13\x1\xFFFF\x1\x12",
				"\x1\x14",
				"\x1\x15",
				"",
				"",
				"",
				"",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xA\xF\x2\xB\x5\xFFFF"+
				"\x1A\xB\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F"+
				"\xB\x1\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF"+
				"\x92E\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"",
				"\x1\x16",
				"\x1\x17",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"\x1\x1A",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				"",
				"",
				"\x1\x1D",
				"",
				"",
				"\x1\xB\x7\xFFFF\x1\xB\x1\xFFFF\x1\xB\x1\xFFFF\xC\xB\x5\xFFFF\x1A\xB"+
				"\x4\xFFFF\x1\xB\x1\xFFFF\x1A\xB\x45\xFFFF\x17\xB\x1\xFFFF\x1F\xB\x1"+
				"\xFFFF\x1F08\xB\x1040\xFFFF\x150\xB\x170\xFFFF\x80\xB\x80\xFFFF\x92E"+
				"\xB\x10D2\xFFFF\x5200\xB\x5900\xFFFF\x200\xB",
				""
			};

		private static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
		private static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
		private static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
		private static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
		private static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
		private static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
		private static readonly short[][] DFA8_transition;

		static DFA8()
		{
			int numStates = DFA8_transitionS.Length;
			DFA8_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA8_transition[i] = DFA.UnpackEncodedString(DFA8_transitionS[i]);
			}
		}

		public DFA8( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 8;
			this.eot = DFA8_eot;
			this.eof = DFA8_eof;
			this.min = DFA8_min;
			this.max = DFA8_max;
			this.accept = DFA8_accept;
			this.special = DFA8_special;
			this.transition = DFA8_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( T__16 | T__17 | T__18 | NUMBER | FLOAT | X | MAX | FTL | FR | TF | NOTE | WORD | WS );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}

} // namespace PowerLog.Parser
