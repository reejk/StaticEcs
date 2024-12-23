using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal class BitMask {
        internal static readonly ushort[] BitsLut = {
            0, 1, 17, 2, 18, 50, 3, 57, 47, 19, 22, 51, 29, 4, 33, 58,
            15, 48, 20, 27, 25, 23, 52, 41, 54, 30, 38, 5, 43, 34, 59, 8,
            63, 16, 49, 56, 46, 21, 28, 32, 14, 26, 24, 40, 53, 37, 42, 7,
            62, 55, 45, 31, 13, 39, 36, 6, 61, 44, 12, 35, 60, 11, 10, 9,
        };
        
        private ulong[] _bitMap;
        internal ushort _len;
        internal ulong[] _buffer;
        private byte _freeCount;
        private byte _borrowed;
        private byte _size;

        [MethodImpl(AggressiveInlining)]
        internal void Create(ulong[] bitMap, byte size, ushort maskLen) {
            _bitMap = bitMap;
            _size = size;
            _len = maskLen;
            _buffer = new ulong[size * maskLen];
            _freeCount = size;
            _borrowed = 0;
        }

        [MethodImpl(AggressiveInlining)]
        internal void SetNewBitMap(ulong[] bitMap) {
            _bitMap = bitMap;
        }

        [MethodImpl(AggressiveInlining)]
        internal void ResizeBuffer(ushort maskLen) {
            var oldBufferLength = _buffer.Length;
            Array.Resize(ref _buffer, _buffer.Length * maskLen);
            for (var i = oldBufferLength - 1; i > 0; i--) {
                for (var j = _len - 1; j >= 0; j--) {
                    var idx = i * _len + j;
                    ref var bits = ref _buffer[idx];
                    _buffer[idx + i] = bits;
                    bits = 0UL;
                }
            }

            _len = maskLen;
        }

        [MethodImpl(AggressiveInlining)]
        internal byte BorrowBuf() {
            var maskBufId = --_freeCount;
            var offset = maskBufId * _len;
            for (var i = 0; i < _len; i++) {
                _buffer[offset + i] = 0UL;
            }

            _borrowed++;
            return maskBufId;
        }

        [MethodImpl(AggressiveInlining)]
        internal void DropBuf(byte id) {
            _borrowed--;
            if (_borrowed == 0) {
                _freeCount = _size;
            }
        }

        [MethodImpl(AggressiveInlining)]
        internal void Destroy() {
            _buffer = null;
            _bitMap = null;
            _len = 0;
            _size = 0;
            _borrowed = 0;
            _freeCount = 0;
        }

        [MethodImpl(AggressiveInlining)]
        public void Set(int bitMapIdx, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bitMapIdx * _len + div;
            _bitMap[index] |= 1UL << rem;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bufId * _len + div;
            _buffer[index] |= 1UL << rem;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3, ushort bit4) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
            _buffer[offset + (ushort) (bit4 >> 6)] |= 1UL << (ushort) (bit4 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3, ushort bit4, ushort bit5) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
            _buffer[offset + (ushort) (bit4 >> 6)] |= 1UL << (ushort) (bit4 & 63);
            _buffer[offset + (ushort) (bit5 >> 6)] |= 1UL << (ushort) (bit5 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3, ushort bit4, ushort bit5, ushort bit6) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
            _buffer[offset + (ushort) (bit4 >> 6)] |= 1UL << (ushort) (bit4 & 63);
            _buffer[offset + (ushort) (bit5 >> 6)] |= 1UL << (ushort) (bit5 & 63);
            _buffer[offset + (ushort) (bit6 >> 6)] |= 1UL << (ushort) (bit6 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3, ushort bit4, ushort bit5, ushort bit6, ushort bit7) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
            _buffer[offset + (ushort) (bit4 >> 6)] |= 1UL << (ushort) (bit4 & 63);
            _buffer[offset + (ushort) (bit5 >> 6)] |= 1UL << (ushort) (bit5 & 63);
            _buffer[offset + (ushort) (bit6 >> 6)] |= 1UL << (ushort) (bit6 & 63);
            _buffer[offset + (ushort) (bit7 >> 6)] |= 1UL << (ushort) (bit7 & 63);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetInBuffer(byte bufId, ushort bit1, ushort bit2, ushort bit3, ushort bit4, ushort bit5, ushort bit6, ushort bit7, ushort bit8) {
            var offset = bufId * _len;
            _buffer[offset + (ushort) (bit1 >> 6)] |= 1UL << (ushort) (bit1 & 63);
            _buffer[offset + (ushort) (bit2 >> 6)] |= 1UL << (ushort) (bit2 & 63);
            _buffer[offset + (ushort) (bit3 >> 6)] |= 1UL << (ushort) (bit3 & 63);
            _buffer[offset + (ushort) (bit4 >> 6)] |= 1UL << (ushort) (bit4 & 63);
            _buffer[offset + (ushort) (bit5 >> 6)] |= 1UL << (ushort) (bit5 & 63);
            _buffer[offset + (ushort) (bit6 >> 6)] |= 1UL << (ushort) (bit6 & 63);
            _buffer[offset + (ushort) (bit7 >> 6)] |= 1UL << (ushort) (bit7 & 63);
            _buffer[offset + (ushort) (bit8 >> 6)] |= 1UL << (ushort) (bit8 & 63);
        }

        [MethodImpl(AggressiveInlining)]
        public void Del(int bitMapIdx, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bitMapIdx * _len + div;
            _bitMap[index] &= ~(1UL << rem);
        }

        [MethodImpl(AggressiveInlining)]
        public void DelInBuffer(byte bufId, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bufId * _len + div;
            _buffer[index] &= ~(1UL << rem);
        }

        [MethodImpl(AggressiveInlining)]
        public bool Has(int bitMapIdx, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bitMapIdx * _len + div;
            return (_bitMap[index] & (1UL << rem)) != 0UL;
        }

        [MethodImpl(AggressiveInlining)]
        public bool HasInBuffer(byte bufId, ushort bitPos) {
            var div = (ushort) (bitPos >> 6);
            var rem = (ushort) (bitPos & 63);
            var index = bufId * _len + div;
            return (_buffer[index] & (1UL << rem)) != 0UL;
        }

        [MethodImpl(AggressiveInlining)]
        public bool IsEmpty(int bitMapIdx) {
            for (int i = bitMapIdx * _len, iMax = (bitMapIdx + 1) * _len; i < iMax; i++) {
                if (_bitMap[i] != 0UL) {
                    return false;
                }
            }

            return true;
        }

        [MethodImpl(AggressiveInlining)]
        public bool IsEmptyBuffer(byte bufId) {
            for (int i = bufId * _len, iMax = (bufId + 1) * _len; i < iMax; i++) {
                if (_buffer[i] != 0UL) {
                    return false;
                }
            }

            return true;
        }

        [MethodImpl(AggressiveInlining)]
        public ushort Len(int bitMapIdx) {
            ushort count = 0;
            var offset = bitMapIdx * _len;
            var endOffset = offset + _len;
            for (; offset < endOffset; offset++) {
                var v = _bitMap[offset];
                v -= (v >> 1) & 0x5555555555555555;
                v = (v & 0x3333333333333333) + ((v >> 2) & 0x3333333333333333);
                count += (ushort) ((((v + (v >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56);
            }

            return count;
        }

        [MethodImpl(AggressiveInlining)]
        public ushort LenBuffer(byte bufId) {
            ushort count = 0;
            var offset = bufId * _len;
            var endOffset = offset * _len;
            for (; offset < endOffset; offset++) {
                var v = _buffer[offset];
                v -= (v >> 1) & 0x5555555555555555;
                v = (v & 0x3333333333333333) + ((v >> 2) & 0x3333333333333333);
                count += (ushort) ((((v + (v >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56);
            }

            return count;
        }

        [MethodImpl(AggressiveInlining)]
        public int GetMinIndex(int bitMapIdx) {
            var offset = bitMapIdx * _len;
            for (var i = 0; i < _len; i++, offset++) {
                var v = _bitMap[offset];
                if (v != 0UL) {
                    return (i << 6) + BitsLut[((ulong) ((long) v & -(long) v) * 0x37E84A99DAE458F) >> 58];
                }
            }

            return -1;
        }

        [MethodImpl(AggressiveInlining)]
        public int GetMinIndexBuffer(byte BufId) {
            var offset = BufId * _len;
            for (var i = 0; i < _len; i++, offset++) {
                var v = _buffer[offset];
                if (v != 0UL) {
                    return (i << 6) + BitsLut[((ulong) ((long) v & -(long) v) * 0x37E84A99DAE458F) >> 58];
                }
            }

            return -1;
        }

        [MethodImpl(AggressiveInlining)]
        public void ClearAll(int bitMapIdx) {
            var srcOffset = bitMapIdx * _len;
            var srcOffsetEmd = srcOffset + _len;
            for (; srcOffset < srcOffsetEmd; srcOffset++) {
                _bitMap[srcOffset] = 0UL;
            }
        }

        [MethodImpl(AggressiveInlining)]
        public void ClearAllInBuffer(byte BufId) {
            var srcOffset = BufId * _len;
            var srcOffsetEmd = srcOffset + _len;
            for (; srcOffset < srcOffsetEmd; srcOffset++) {
                _buffer[srcOffset] = 0UL;
            }
        }

        [MethodImpl(AggressiveInlining)]
        public bool HasAll(int bitMapIdx, byte bufId) {
            if (_len < 2) {
                var rhs = _buffer[bufId];
                return (_bitMap[bitMapIdx] & rhs) == rhs;
            }

            return HasAllArray(bitMapIdx, bufId);
        }
        
        private bool HasAllArray(int bitMapIdx, byte bufId) {
            var srcOffset = bitMapIdx * _len;
            var srcOffsetEnd = srcOffset + _len;
            var bufOffset = bufId * _len;
            for (; srcOffset < srcOffsetEnd; srcOffset++, bufOffset++) {
                var rhs = _buffer[bufOffset];
                if ((_bitMap[srcOffset] & rhs) != rhs) {
                    return false;
                }
            }

            return true;
        }

        [MethodImpl(AggressiveInlining)]
        public bool HasAny(int bitMapIdx, byte bufId) {
            if (_len < 2) {
                return (_bitMap[bitMapIdx] & _buffer[bufId]) != 0UL;
            }

            return HasAnyArray(bitMapIdx, bufId);
        }

        private bool HasAnyArray(int bitMapIdx, byte bufId) {
            var srcOffset = bitMapIdx * _len;
            var srcOffsetEnd = srcOffset + _len;
            var bufOffset = bufId * _len;
            for (; srcOffset < srcOffsetEnd; srcOffset++, bufOffset++) {
                if ((_bitMap[srcOffset] & _buffer[bufOffset]) != 0UL) {
                    return true;
                }
            }

            return false;
        }

        [MethodImpl(AggressiveInlining)]
        public bool HasAllAndExc(int bitMapIdx, byte bufIdAll, byte bufIdExc) {
            if (_len < 2) {
                var lhs = _bitMap[bitMapIdx];
                var rhs = _buffer[bufIdAll];
                return (lhs & rhs) == rhs && (lhs & _buffer[bufIdExc]) == 0UL;
            }

            return HasAllAndExcArray(bitMapIdx, bufIdAll, bufIdExc);
        }
        
        private bool HasAllAndExcArray(int bitMapIdx, byte bufIdAll, byte bufIdExc) {
            var srcOffset = bitMapIdx * _len;
            var srcOffsetEnd = srcOffset + _len;
            var bufIdAllOffset = bufIdAll * _len;
            var bufIdExcOffset = bufIdExc * _len;
            for (; srcOffset < srcOffsetEnd; srcOffset++, bufIdAllOffset++, bufIdExcOffset++) {
                var lhs = _bitMap[srcOffset];
                var rhs = _buffer[bufIdAllOffset];
                if ((lhs & rhs) != rhs || (lhs & _buffer[bufIdExcOffset]) != 0UL) {
                    return false;
                }
            }

            return true;
        }

        [MethodImpl(AggressiveInlining)]
        public bool NotHasAny(int bitMapIdx, byte bufId) {
            if (_len < 2) {
                return (_bitMap[bitMapIdx] & _buffer[bufId]) == 0UL;
            }

            return NotHasAnyArray(bitMapIdx, bufId);
        }
        
        private bool NotHasAnyArray(int bitMapIdx, byte bufId) {
            var srcOffset = bitMapIdx * _len;
            var srcOffsetEnd = srcOffset + _len;
            var bufOffset = bufId * _len;
            for (; srcOffset < srcOffsetEnd; srcOffset++, bufOffset++) {
                if ((_bitMap[srcOffset] & _buffer[bufOffset]) != 0UL) {
                    return false;
                }
            }

            return true;
        }
    }
}