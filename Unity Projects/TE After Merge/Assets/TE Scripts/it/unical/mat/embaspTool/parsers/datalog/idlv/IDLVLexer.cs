//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from IDLVLexer.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class IDLVLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		IGNORE=1, COMMA=2, INTEGER_CONSTANT=3, ATOM_END=4, IDENTIFIER=5, STRING_CONSTANT=6, 
		TERMS_BEGIN=7, TERMS_END=8;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"IGNORE", "COMMA", "INTEGER_CONSTANT", "ATOM_END", "IDENTIFIER", "STRING_CONSTANT", 
		"TERMS_BEGIN", "TERMS_END", "INT", "NL", "WS"
	};


	public IDLVLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public IDLVLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "','", null, "'.'", null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "IGNORE", "COMMA", "INTEGER_CONSTANT", "ATOM_END", "IDENTIFIER", 
		"STRING_CONSTANT", "TERMS_BEGIN", "TERMS_END"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "IDLVLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static IDLVLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\n', 'G', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', 
		'\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', 
		'\v', '\x4', '\f', '\t', '\f', '\x3', '\x2', '\x3', '\x2', '\x5', '\x2', 
		'\x1C', '\n', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\a', '\x6', '(', '\n', '\x6', '\f', '\x6', '\xE', 
		'\x6', '+', '\v', '\x6', '\x3', '\a', '\x3', '\a', '\a', '\a', '/', '\n', 
		'\a', '\f', '\a', '\xE', '\a', '\x32', '\v', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\a', '\n', '=', '\n', '\n', '\f', '\n', '\xE', 
		'\n', '@', '\v', '\n', '\x5', '\n', '\x42', '\n', '\n', '\x3', '\v', '\x3', 
		'\v', '\x3', '\f', '\x3', '\f', '\x2', '\x2', '\r', '\x3', '\x3', '\x5', 
		'\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', 
		'\x11', '\n', '\x13', '\x2', '\x15', '\x2', '\x17', '\x2', '\x3', '\x2', 
		'\t', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\x32', ';', 
		'\x43', '\\', '\x61', '\x61', '\x63', '|', '\x3', '\x2', '$', '$', '\x3', 
		'\x2', '\x33', ';', '\x3', '\x2', '\x32', ';', '\x4', '\x2', '\f', '\f', 
		'\xF', '\xF', '\x4', '\x2', '\v', '\v', '\"', '\"', '\x2', 'H', '\x2', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x11', '\x3', '\x2', '\x2', '\x2', '\x3', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x5', '\x1F', '\x3', '\x2', '\x2', '\x2', '\a', '!', '\x3', '\x2', 
		'\x2', '\x2', '\t', '#', '\x3', '\x2', '\x2', '\x2', '\v', '%', '\x3', 
		'\x2', '\x2', '\x2', '\r', ',', '\x3', '\x2', '\x2', '\x2', '\xF', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x11', '\x37', '\x3', '\x2', '\x2', '\x2', 
		'\x13', '\x41', '\x3', '\x2', '\x2', '\x2', '\x15', '\x43', '\x3', '\x2', 
		'\x2', '\x2', '\x17', '\x45', '\x3', '\x2', '\x2', '\x2', '\x19', '\x1C', 
		'\x5', '\x15', '\v', '\x2', '\x1A', '\x1C', '\x5', '\x17', '\f', '\x2', 
		'\x1B', '\x19', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', 
		'\b', '\x2', '\x2', '\x2', '\x1E', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', ' ', '\a', '.', '\x2', '\x2', ' ', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '!', '\"', '\x5', '\x13', '\n', '\x2', '\"', '\b', '\x3', '\x2', 
		'\x2', '\x2', '#', '$', '\a', '\x30', '\x2', '\x2', '$', '\n', '\x3', 
		'\x2', '\x2', '\x2', '%', ')', '\t', '\x2', '\x2', '\x2', '&', '(', '\t', 
		'\x3', '\x2', '\x2', '\'', '&', '\x3', '\x2', '\x2', '\x2', '(', '+', 
		'\x3', '\x2', '\x2', '\x2', ')', '\'', '\x3', '\x2', '\x2', '\x2', ')', 
		'*', '\x3', '\x2', '\x2', '\x2', '*', '\f', '\x3', '\x2', '\x2', '\x2', 
		'+', ')', '\x3', '\x2', '\x2', '\x2', ',', '\x30', '\a', '$', '\x2', '\x2', 
		'-', '/', '\n', '\x4', '\x2', '\x2', '.', '-', '\x3', '\x2', '\x2', '\x2', 
		'/', '\x32', '\x3', '\x2', '\x2', '\x2', '\x30', '.', '\x3', '\x2', '\x2', 
		'\x2', '\x30', '\x31', '\x3', '\x2', '\x2', '\x2', '\x31', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x32', '\x30', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\x34', '\a', '$', '\x2', '\x2', '\x34', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '\x36', '\a', '*', '\x2', '\x2', '\x36', '\x10', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\x38', '\a', '+', '\x2', '\x2', '\x38', '\x12', 
		'\x3', '\x2', '\x2', '\x2', '\x39', '\x42', '\a', '\x32', '\x2', '\x2', 
		':', '>', '\t', '\x5', '\x2', '\x2', ';', '=', '\t', '\x6', '\x2', '\x2', 
		'<', ';', '\x3', '\x2', '\x2', '\x2', '=', '@', '\x3', '\x2', '\x2', '\x2', 
		'>', '<', '\x3', '\x2', '\x2', '\x2', '>', '?', '\x3', '\x2', '\x2', '\x2', 
		'?', '\x42', '\x3', '\x2', '\x2', '\x2', '@', '>', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\x39', '\x3', '\x2', '\x2', '\x2', '\x41', ':', '\x3', 
		'\x2', '\x2', '\x2', '\x42', '\x14', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'\x44', '\t', '\a', '\x2', '\x2', '\x44', '\x16', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\x46', '\t', '\b', '\x2', '\x2', '\x46', '\x18', '\x3', 
		'\x2', '\x2', '\x2', '\b', '\x2', '\x1B', ')', '\x30', '>', '\x41', '\x3', 
		'\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}