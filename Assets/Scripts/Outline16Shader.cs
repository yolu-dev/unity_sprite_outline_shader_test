using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace ScreenPocket
{
    public class Outline16Shader : OutlineShader
    {
        protected Outline16Shader()
        { }

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;

            base.ModifyMesh(vh);

            var verts = ListPool<UIVertex>.Get();
            vh.GetUIVertexStream(verts);

            var outline8Count = verts.Count;
            var baseCount = verts.Count / 9;
            var neededCapacity = baseCount * 17;//�{�`��+16����
            if (verts.Capacity < neededCapacity)
                verts.Capacity = neededCapacity;

            var rot = 90f / 4f;
            //���炷
            var rotVectorA = Quaternion.AngleAxis(rot, Vector3.forward) * effectDistance;

            var start = outline8Count - baseCount;
            var end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, rotVectorA.x, rotVectorA.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, rotVectorA.x, -rotVectorA.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, -rotVectorA.x, rotVectorA.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, -rotVectorA.x, -rotVectorA.y);
            //���Α��ɂ��炷
            var rotVectorB = Quaternion.AngleAxis(-rot, Vector3.forward) * effectDistance;
            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, rotVectorB.x, rotVectorB.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, rotVectorB.x, -rotVectorB.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, -rotVectorB.x, rotVectorB.y);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, end, -rotVectorB.x, -rotVectorB.y);


            vh.Clear();
            vh.AddUIVertexTriangleStream(verts);
            ListPool<UIVertex>.Release(verts);
        }
    }
}