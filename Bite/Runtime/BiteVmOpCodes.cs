﻿namespace Bite.Runtime
{

public enum BiteVmOpCodes : byte
{
    OpNone,
    OpPopStack,
    OpConstant,
    OpAssign,
    OpPlusAssign,
    OpMinusAssign,
    OpMultiplyAssign,
    OpDivideAssign,
    OpModuloAssign,
    OpBitwiseAndAssign,
    OpBitwiseOrAssign,
    OpBitwiseXorAssign,
    OpBitwiseLeftShiftAssign,
    OpBitwiseRightShiftAssign,
    OpPushNextAssignmentOnStack,
    OpAdd,
    OpSubtract,
    OpMultiply,
    OpDivide,
    OpModulo,
    OpEqual,
    OpNotEqual,
    OpLess,
    OpLessOrEqual,
    OpGreater,
    OpGreaterEqual,
    OpAnd,
    OpOr,
    OpBitwiseOr,
    OpBitwiseAnd,
    OpBitwiseXor,
    OpBitwiseLeftShift,
    OpBitwiseRightShift,
    OpPostfixIncrement,
    OpPostfixDecrement,
    OpPrefixIncrement,
    OpPrefixDecrement,
    OpNegate,
    OpAffirm,
    OpCompliment,
    OpNot,
    OpDefineModule,
    OpDefineClass,
    OpUsingStatmentHead,
    OpUsingStatmentEnd,
    OpDefineMethod,
    OpDefineCallableMethod,
    OpDefineVar,
    OpDeclareVar,
    OpSetVar,
    OpSetVarExternal,
    OpGetVar,
    OpGetNextVarByRef,
    OpGetVarExternal,
    OpGetModule,
    OpDefineInstance,
    OpSetInstance,
    OpJumpIfFalse,
    OpJump,
    OpTernary,
    OpEnterBlock,
    OpExitBlock,
    OpWhileLoop,
    OpBindToFunction,
    OpGetElement,
    OpSetElement,
    OpCallFunctionByName,
    OpCallFunctionFromStack,
    OpSetFunctionParameterName,
    OpCallMemberFunction,
    OpGetMember,
    OpGetMemberWithString,
    OpSetMember,
    OpSetMemberWithString,
    OpKeepLastItemOnStack,
    OpBreak,
    OpReturn,
    OpSwitchContext,
    OpReturnContext
}

}
