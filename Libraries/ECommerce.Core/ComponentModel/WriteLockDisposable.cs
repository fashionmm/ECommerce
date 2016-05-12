using System;
using System.Threading;

namespace ECommerce.Core.ComponentModel
{
    /// <summary>
    /// 提供了一种方便的方法来实现对资源的锁定访问。
    /// </summary>
    /// <remarks>
    /// 作为一个基础设施类
    /// </remarks>
    public class WriteLockDisposable : IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;

        /// <summary>
        /// 初始化一个新的<see cref="WriteLockDisposable"/> class.
        /// </summary>
        /// <param name="rwLock">读写锁。The rw lock.</param>
        public WriteLockDisposable(ReaderWriterLockSlim rwLock)
        {
            _rwLock = rwLock;
            _rwLock.EnterWriteLock();
        }

        void IDisposable.Dispose()
        {
            _rwLock.ExitWriteLock();
        }
    }
}
